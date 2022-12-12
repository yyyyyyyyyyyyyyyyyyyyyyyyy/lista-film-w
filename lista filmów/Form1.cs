namespace lista_filmów
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OdczytZPliku();
        }
        private void DodawanieDanych(string tytul, string rezyser, string data, string aktor)
        {
            ListViewItem item = new ListViewItem(new string[] { tytul, rezyser, data, aktor });
            listView1.Items.Add(item);
        }
        private void DodawanieDanych(string[] dane)
        {
            ListViewItem item = new ListViewItem(dane);
            listView1.Items.Add(item);
        }
        private void UsuwanieDanych()
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
        }
        private string[] WierszeDoPliku()
        {
            string[] linie = new string[listView1.Items.Count];
            int pomidor = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                linie[pomidor] = "";
                for (int k = 0; k < item.SubItems.Count; k++)
                    linie[pomidor] += item.SubItems[k].Text + "*";
                pomidor++;
            }
            return linie;
        }
        private void OdczytZPliku()
        {

            if (!File.Exists("filmy.txt"))
                return;

            string[] linie = File.ReadAllLines("filmy.txt");
            foreach (string linia in linie)
            {
                string[] temp = linia.Split('*');
                DodawanieDanych(temp);
            }

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonzap_Click(object sender, EventArgs e)
        {
            string[] linie = WierszeDoPliku();
            File.WriteAllLines("filmy.txt", linie);
        }

        private void buttonzam_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void buttondod_Click(object sender, EventArgs e)
        {
            DodawanieDanych(textBox1.Text, textBox3.Text, dateTimePicker1.Text, textBox2.Text);
        }
        private void usuńWybraneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuwanieDanych();
        }

    }
}