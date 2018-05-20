using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Business;

namespace ImSys
{
    public partial class Inicial : Form
    {
        //int idInteresse = 0;
        AgendaDominio agedom = new AgendaDominio();
        public Inicial()
        {
            InitializeComponent();
            
            dgvInteresses.DataSource = agedom.listarTodosInteressesSemVisita();
            TimerNovosInteresses.Tick += new EventHandler(TimerNovosInteresses_Tick);
            TimerNovosInteresses.Interval = 60000;
            TimerNovosInteresses.Enabled = true;
            TimerNovosInteresses.Start();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroPessoa frmPessoa = new CadastroPessoa();
            frmPessoa.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Agendamento agendamento = new Agendamento();
            agendamento.Show();
        }

        private void TimerNovosInteresses_Tick(object sender, EventArgs e)
        {
            AgendaDominio agedom = new AgendaDominio();
            dgvInteresses.DataSource = agedom.listarTodosInteressesSemVisita();

        }

        private void dgvInteresses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dgvInteresses.CurrentRow.Cells[0].Value;
            AgendaDominio agedom = new AgendaDominio();
            interesse inte = agedom.selecionarInteresseComID(id);
            inte.status = "Visita marcada";
            agedom.modificarStatusInteresse(inte);
            dgvInteresses.DataSource = agedom.listarTodosInteressesSemVisita();
        }
    }
}
