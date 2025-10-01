using System;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace chapella_video_compressor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            groupBox2.MouseDown += GroupBox2_MouseDown;
            groupBox1.MouseDown += GroupBox1_MouseDown;

            videoToCompressTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            videoToCompressTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            videoToCompressTxt.AutoCompleteCustomSource = new AutoCompleteStringCollection();

            videoCompressDestinationFolderTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            videoCompressDestinationFolderTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            videoCompressDestinationFolderTxt.AutoCompleteCustomSource = new AutoCompleteStringCollection();
        }

        private async void compressVideoBtn_Click(object sender, EventArgs e)
        {
            string inputFile = videoToCompressTxt.Text;
            string outputFolder = videoCompressDestinationFolderTxt.Text;

            if (string.IsNullOrWhiteSpace(inputFile) || string.IsNullOrWhiteSpace(outputFolder))
            {
                MessageBox.Show("Please select an input video and an output folder.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            compressVideoBtn.Enabled = false;
            videoCompressionProgressTxt.Text = "Starting compression...";

            try
            {
                await RunFfmpegCompression(inputFile, outputFolder);

                MessageBox.Show("Compression completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during compression:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                videoCompressionProgressTxt.Text = "An error occurred.";
            }
            finally
            {
                compressVideoBtn.Enabled = true;
            }
        }
        private Task RunFfmpegCompression(string inputFile, string fullOutputPath)
        {
            var tcs = new TaskCompletionSource<bool>();

            string arguments = $"-y -i \"{inputFile}\" -vcodec libx265 -crf 28 \"{fullOutputPath}\"";
            Debug.WriteLine($"FFmpeg command: ffmpeg.exe {arguments}");

            var psi = new ProcessStartInfo
            {
                FileName = @"ffmpeg.exe", //copy the full directory of ffmpeg here (or you can simply copy ffmpeg to the "bin" folder)
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            var proc = new Process
            {
                StartInfo = psi,
                EnableRaisingEvents = true
            };

            var durationRegex = new Regex(@"Duration:\s*(\d{2}:\d{2}:\d{2}\.\d+)", RegexOptions.Compiled);
            var timeRegex = new Regex(@"time=(\d{2}:\d{2}:\d{2}\.\d+)", RegexOptions.Compiled);
            TimeSpan totalDuration = TimeSpan.Zero;
            var errorOutput = new System.Text.StringBuilder();

            proc.ErrorDataReceived += (s, ea) =>
            {
                if (string.IsNullOrEmpty(ea.Data)) return;
                string line = ea.Data;
                if (!durationRegex.IsMatch(line) && !timeRegex.IsMatch(line)) { errorOutput.AppendLine(line); }
                Match mDur = durationRegex.Match(line);
                if (mDur.Success) { TimeSpan.TryParse(mDur.Groups[1].Value, out totalDuration); return; }
                Match mTime = timeRegex.Match(line);
                if (mTime.Success)
                {
                    if (TimeSpan.TryParse(mTime.Groups[1].Value, out var currentTime))
                    {
                        double percentage = totalDuration > TimeSpan.Zero ? Math.Min(100.0, (currentTime.TotalSeconds / totalDuration.TotalSeconds) * 100.0) : 0;
                        string currentStr = currentTime.ToString(@"hh\:mm\:ss\.ff");
                        string totalStr = totalDuration.ToString(@"hh\:mm\:ss\.ff");
                        BeginInvoke((Action)(() => { videoCompressionProgressTxt.Text = $"{currentStr} / {totalStr} (progress:{percentage:0.0}%)"; }));
                    }
                }
            };

            proc.Exited += (s, ea) =>
            {
                if (proc.ExitCode != 0)
                {
                    var error = new Exception($"FFmpeg exited with code {proc.ExitCode}.\n\nOutput:\n{errorOutput}");
                    tcs.TrySetException(error);
                }
                else
                {
                    string finalTime = totalDuration.ToString(@"hh\:mm\:ss\.ff");
                    BeginInvoke((Action)(() => { videoCompressionProgressTxt.Text = $"{finalTime} / {finalTime} (100.0%)"; }));
                    tcs.TrySetResult(true);
                }
                proc.Dispose();
            };

            proc.Start();
            proc.BeginErrorReadLine();
            return tcs.Task;
        }

        private void videoToCompressDirBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select video file to compress";
            ofd.Filter = "mp4 video|*.mp4|mov video|*.mov|avi video|*.avi|mkv video|*.mkv|flv video|*.flv|wmv video|*.wmv|m4v video|*.m4v|All Files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                videoToCompressTxt.Text = ofd.FileName;
            }
        }

        private void destinationFolderBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(videoToCompressTxt.Text) || !File.Exists(videoToCompressTxt.Text))
            {
                MessageBox.Show("Please select a video file first.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Title = "select sestination folder";
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string fileName = Path.GetFileName(videoToCompressTxt.Text);
                videoCompressDestinationFolderTxt.Text = Path.Combine(dialog.FileName, fileName);
            }
        }

        private string _videoToCompressTxtOGtext = "drag and drop your video file here...";
        private string _videoCompressDestinationFolderTxtOGtext = "drag and drop your destination folder here...";
        private void videoToCompressTxt_Enter(object sender, EventArgs e)
        {
            if (videoToCompressTxt.Text == _videoToCompressTxtOGtext)
            {
                videoToCompressTxt.Text = "";
            }
        }

        private void videoToCompressTxt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(videoToCompressTxt.Text))
                videoToCompressTxt.Text = _videoToCompressTxtOGtext;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            HandleFocusReset();
        }

        private void GroupBox2_MouseDown(object sender, MouseEventArgs e)
        {
            HandleFocusReset();
        }
        
        private void GroupBox1_MouseDown(object sender, MouseEventArgs e)
        {
            HandleFocusReset();
        }

        private void videoCompressDestinationFolderTxt_Enter(object sender, EventArgs e)
        {
            if (videoCompressDestinationFolderTxt.Text == _videoCompressDestinationFolderTxtOGtext)
            {
                if (_videoCompressDestinationFolderTxtOGtext == null)
                    _videoCompressDestinationFolderTxtOGtext = videoCompressDestinationFolderTxt.Text;

                videoCompressDestinationFolderTxt.Text = "";
            }
        }

        private void videoCompressDestinationFolderTxt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(videoCompressDestinationFolderTxt.Text))
                videoCompressDestinationFolderTxt.Text = _videoCompressDestinationFolderTxtOGtext;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ActiveControl = null;
        }

        private void HandleFocusReset()
        {
            ActiveControl = null;
        }

        private void videoToCompressTxt_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files.Length == 1 && File.Exists(files[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void videoToCompressTxt_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0 && File.Exists(files[0]))
            {
                videoToCompressTxt.Text = files[0];
            }
        }

        private void videoCompressDestinationFolderTxt_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (paths.Length == 1 && Directory.Exists(paths[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void videoCompressDestinationFolderTxt_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (paths.Length > 0 && Directory.Exists(paths[0]))
            {
                string droppedFolderPath = paths[0];
                string inputFilePath = videoToCompressTxt.Text;

                if (string.IsNullOrWhiteSpace(inputFilePath) || !File.Exists(inputFilePath))
                {
                    MessageBox.Show("Please select or drag-and-drop an input video file first.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string fileName = Path.GetFileName(inputFilePath);
                string combinedPath = Path.Combine(droppedFolderPath, fileName);
                videoCompressDestinationFolderTxt.Text = combinedPath;
            }
        }
    }
}
