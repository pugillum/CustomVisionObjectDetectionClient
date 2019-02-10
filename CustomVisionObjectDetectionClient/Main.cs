using ConvertToJson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebEye.Controls.WinForms.WebCameraControl;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        private static string _predictionKey;
        private static string _predictionEndpointUrl;
        private List<Prediction> _predictions;
        private double _predictionThreshold;
        private int _cameraId;

        private class ComboBoxItem
        {
            public ComboBoxItem(WebCameraId id)
            {
                _id = id;
            }

            private readonly WebCameraId _id;
            public WebCameraId Id
            {
                get { return _id; }
            }

            public override string ToString()
            {
                // Generates the text shown in the combo box.
                return _id.Name;
            }
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _predictionKey = ConfigurationManager.AppSettings.Get("predictionKey");
            // REMEMBER!!! If there are multiple iterations you'll need to include the ID of the iteration, like
            // so ?iterationId=[guid] (after image)
            _predictionEndpointUrl = ConfigurationManager.AppSettings.Get("predictionUrl");

            _predictions = new List<Prediction>();
            _predictionThreshold = Convert.ToDouble(ConfigurationManager.AppSettings.Get("threshold"));
            _cameraId = Convert.ToInt32(ConfigurationManager.AppSettings.Get("cameraId"));

            ClearAll();
        }

        private async Task MakeRequest(byte[] byteData)
        {
            ClearAll();

            using (var content = new ByteArrayContent(byteData))
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Prediction-Key", _predictionKey);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                startBusyIndicator();
                HttpResponseMessage response = await client.PostAsync(_predictionEndpointUrl, content);
                stopBusyIndicator();
                string result = await response.Content.ReadAsStringAsync();
                HandleResult(result);
            }
        }

        private void ClearAll()
        {
            _predictions.Clear();
            labelLoadingImage.Visible = false;
        }

        private void HandleResult(string json)
        {
            var customVisionResult = CustomVisionResult.FromJson(json);

            //extract bounding boxes
            var threshold =
            _predictions = customVisionResult.Predictions.Where(p => p.Probability > _predictionThreshold).ToList();

            pictureBox.Refresh();
        }

        private byte[] GetFileAsByteArray(string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }

        private async void buttonFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(op.FileName);
                    byte[] byteData = GetFileAsByteArray(op.FileName);
                    await MakeRequest(byteData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failure: " + ex.Message);
            }
        }

        private void setCamera(bool on)
        {
            var cameras = webCameraControl1.GetVideoCaptureDevices().ToList();
            if (cameras.Count > 0)
            {
                if (on)
                {
                    webCameraControl1.StartCapture(cameras[_cameraId]);
                }
                else
                {
                    webCameraControl1.StopCapture();
                }
            }

        }

        private void startBusyIndicator()
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void stopBusyIndicator()
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            var iterator = 1;
            while (true)
            {

                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(300);
                    worker.ReportProgress(iterator);
                    iterator++;
                    if (iterator > 6)
                    {
                        iterator = 1;
                    }
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var loadingText = "Loading" + new String('.', e.ProgressPercentage);
            if (!labelLoadingImage.Visible)
            {
                labelLoadingImage.Visible = true;
            }
            labelLoadingImage.Text = loadingText;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelLoadingImage.Visible = false;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            var actualPictureRect = getActualPictureRect();

            foreach (Prediction p in _predictions)
            {
                var left = actualPictureRect.X + (int)(p.BoundingBox.Left * actualPictureRect.Width);
                var top = actualPictureRect.Y + (int)(p.BoundingBox.Top * actualPictureRect.Height);
                var width = (int)(p.BoundingBox.Width * actualPictureRect.Width);
                var height = (int)(p.BoundingBox.Height * actualPictureRect.Height);

                var rect = new Rectangle(left, top, width, height);
                e.Graphics.DrawRectangle(new Pen(Color.Red), rect);
                drawTag(left, top, p.TagName, e);
            }
        }

        private Rectangle getActualPictureRect()
        {
            var pictureBoxWidth = pictureBox.Width;
            var pictureBoxHeight = pictureBox.Height;
            var preferredWidth = pictureBox.PreferredSize.Width;
            var preferredHeight = pictureBox.PreferredSize.Height;

            var actualWidth = Math.Min(pictureBoxWidth, pictureBoxHeight * preferredWidth / preferredHeight);
            var actualHeight = Math.Min(pictureBoxHeight, pictureBoxWidth * preferredHeight / preferredWidth);

            var offsetLeft = (int)(pictureBoxWidth - actualWidth) / 2;
            var offsetTop = (int)(pictureBoxHeight - actualHeight) / 2;

            return new Rectangle(offsetLeft, offsetTop, actualWidth, actualHeight);
        }

        private void drawTag(int left, int top, string text, PaintEventArgs e)
        {
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            var textSize = e.Graphics.MeasureString(text, drawFont);
            //var size = g.MeasureString("Text to be highlighted", drawFont);
            var textRectangle = new RectangleF(left, top, textSize.Width, textSize.Height);

            //Filling a rectangle before drawing the string.
            e.Graphics.FillRectangle(Brushes.Red, textRectangle);

            e.Graphics.DrawString(text, drawFont, drawBrush, left, top);
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private async void buttonCamera_Click(object sender, EventArgs e)
        {
            try
            {
                // if camera is on take a snapshot and display the image and result
                if (!buttonFile.Enabled)
                {
                    buttonFile.Enabled = true;
                    buttonCamera.Text = "Camera";
                    var bitmap = webCameraControl1.GetCurrentImage();
                    setCamera(false);
                    webCameraControl1.Visible = false;
                    pictureBox.Visible = true;
                    pictureBox.Image = bitmap;
                    byte[] byteData = ImageToByte(bitmap);
                    await MakeRequest(byteData);
                }
                // if not, turn on the webcam
                else
                {
                    buttonFile.Enabled = false;
                    buttonCamera.Text = "Snapshot";
                    webCameraControl1.Visible = true;
                    pictureBox.Visible = false;
                    setCamera(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failure: " + ex.Message);
            }
        }
    }
}
