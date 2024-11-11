using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QRCoder;

namespace GymPrueba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializePictureBox();
        }

        private void InitializePictureBox()
        {
            pictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxQR.Width = 250;
            pictureBoxQR.Height = 250;
        }

        private void buttonGenerarQR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCliente.Text))
            {
                MessageBox.Show("Por favor, ingresa un ID de cliente.");
                return;
            }
            string connectionString = "Server=localhost;Port=3306;Database=Gym;User ID=root;Password=25122004;";
            string query = "SELECT Cli_Id, Cli_Nombre, Cli_Edad, Cli_Telefono, Cli_Telefono_Emer, Cli_Correo, Est_id, Fecha_Creacion, Fecha_termina FROM Cliente WHERE Cli_Id = @CliId";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CliId", textBoxCliente.Text);
                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int cliId = Convert.ToInt32(reader["Cli_Id"]);
                        string nombre = reader["Cli_Nombre"].ToString();
                        int edad = Convert.ToInt32(reader["Cli_Edad"]);
                        string telefono = reader["Cli_Telefono"].ToString();
                        string telefonoEmergencia = reader["Cli_Telefono_Emer"].ToString();
                        string correo = reader["Cli_Correo"].ToString();
                        int estId = Convert.ToInt32(reader["Est_id"]);
                        DateTime fechaCreacion = Convert.ToDateTime(reader["Fecha_Creacion"]);
                        DateTime? fechaTermina = reader["Fecha_termina"] as DateTime?;
                        if (estId == 1)
                        {
                            DateTime fechaActual = DateTime.Now;
                            int diasRestantes = (fechaTermina.HasValue ? (fechaTermina.Value - fechaActual).Days : 0);
                            string qrData = $"ID: {cliId}|Nombre: {nombre}|Edad: {edad}|Telefono: {telefono}|" +
                                            $"Telefono Emergencia: {telefonoEmergencia}|Correo: {correo}|" +
                                            $"Estado: MIEMBRO|Fecha Creacion: {fechaCreacion}|Fecha Termina: " +
                                            $"{(fechaTermina.HasValue ? fechaTermina.Value.ToString("yyyy-MM-dd") : "N/A")}|Dias Restantes: {diasRestantes}";
                            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                            {
                                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
                                using (QRCode qrCode = new QRCode(qrCodeData))
                                {
                                    Bitmap qrCodeImage = qrCode.GetGraphic(20);
                                    pictureBoxQR.Image = qrCodeImage;
                                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                                    saveFileDialog.Filter = "PNG Image|*.png";
                                    saveFileDialog.Title = "Guardar Código QR";
                                    saveFileDialog.FileName = $"{nombre}_QRCode.png";
                                    saveFileDialog.InitialDirectory = @"C:\Users\SALINITAS\Pictures\QR Gym";
                                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        qrCodeImage.Save(saveFileDialog.FileName);
                                        MessageBox.Show("Código QR guardado exitosamente.");
                                    }
                                }
                            }
                        }
                        else if (estId == 2)
                        {
                            MessageBox.Show("El cliente es un visitante. No se generará un código QR.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void UpdateFechaTermina(int cliId)
        {
            string connectionString = "Server=localhost;Port=3306;Database=GymPrueba1;User ID=root;Password=25122004;";
            string updateQuery = @" UPDATE Cliente SET Fecha_termina = DATE_SUB(Fecha_termina, INTERVAL 1 DAY) WHERE Cli_Id = @CliId";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@CliId", cliId);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la fecha de terminación: " + ex.Message);
                }
            }
        }

        private void pictureBoxQR_Click(object sender, EventArgs e)
        {
            if (pictureBoxQR.Image != null)
            {
                string[] qrDataParts = ExtractDataFromQRCode(pictureBoxQR.Image);
                if (qrDataParts.Length > 0)
                {
                    int cliId;
                    if (int.TryParse(qrDataParts[0].Split(':')[1].Trim(), out cliId))
                    {
                        UpdateFechaTermina(cliId);
                        ShowRemainingDays(cliId);
                    }
                }
            }
        }

        private string[] ExtractDataFromQRCode(Image qrImage)
        {
            return new[] { "ID: 1" };
        }

        private void ShowRemainingDays(int cliId)
        {
            string connectionString = "Server=localhost;Port=3306;Database=GymPrueba1;User ID=root;Password=25122004;";
            string query = "SELECT Fecha_termina FROM Cliente WHERE Cli_Id = @CliId";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CliId", cliId);
                try
                {
                    connection.Open();
                    DateTime? fechaTermina = command.ExecuteScalar() as DateTime?;
                    if (fechaTermina.HasValue)
                    {
                        int diasRestantes = (fechaTermina.Value - DateTime.Now).Days;
                        MessageBox.Show($"Información del Cliente:\n" +
                                        $"ID: {cliId}\n" +
                                        $"Dias Restantes: {diasRestantes}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener días restantes: " + ex.Message);
                }
            }
        }

        private void textBoxCliente_TextChanged(object sender, EventArgs e)
        {
        }
    }
}