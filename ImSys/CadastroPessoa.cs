using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Dominio;
using System.IO;




namespace ImSys
{
    public partial class CadastroPessoa : Form
    {
        int iddoimovel = 0;
        int iddocorretor = 0;
        int iddocliente = 0;
        int idcategoriaimovel = 0;
        int iddointeresse = 0;
        int idlocacao = 0;
        FileInfo file1;
        FileInfo file2;
        FileInfo file3;
        FileInfo file4;
        int idvisita = 0;
        permissoes perr;
        permissoes permissao;
        int iddousuario;
        string caminhoImage1 = "";
        string nomeimagem1 = "";
        string caminhoImage2 = "";
        string nomeimagem2 = "";
        string caminhoImage3 = "";
        string nomeimagem3 = "";
        string caminhoImage4 = "";
        string nomeimagem4 = "";
        string usuario = "gentil";
        string senha = "g7nt1l";


        public CadastroPessoa()
        {
            InitializeComponent();
        }

        //tentando fazer o construtor
        public CadastroPessoa(permissoes per)
        {
            InitializeComponent();
            perr = per;
            if(per.gerenciarpagamentoaluguel != "1")
            {
                tabAluguel.Enabled = false;
            }
            if(per.gerenciarpermissoes != "1")
            {
                tabPermissoes.Enabled = false;
            }
            if(per.gerenciarusuario != "1")
            {
                tabUsuario.Enabled = false;
            }
            if(per.gerenciarvendaaluguel != "1")
            {
                tabVenda.Enabled = false;
            }
            if(per.gerenciarvisita != "1")
            {
                tabAgendamento.Enabled = false;
            }
            if(per.publicarimovel != "1")
            {
                cbPublicacao.Enabled = false;
            }

        }
        //se der merda, tira essa parte


        private void CadastroPessoa_Load(object sender, EventArgs e)
        {
            //tabPage2.Enabled = false; usar essa bagaça no controle de permissões
            State objcbestados = new State();
            string nome = "";
            EnderecoBusiness endbus = new EnderecoBusiness();
            EnderecoBusiness endbus2 = new EnderecoBusiness();
            ImovelBusiness catbus = new ImovelBusiness();
            AgendaDominio agedom = new AgendaDominio();
            PessoaDominio pesdom = new PessoaDominio();
            ImovelDominio imodom = new ImovelDominio();

            cbEstado.DataSource = endbus.listarEstados(nome);
            cbEstado.ValueMember = "name";
            cbEstado.DisplayMember = "name";

            cbCidade.DataSource = endbus.listarCidades(cbEstado.SelectedValue.ToString());
            cbCidade.ValueMember = "name";
            cbCidade.DisplayMember = "name";

            cbEstadoCor.DataSource = endbus.listarEstados(nome);
            cbEstadoCor.ValueMember = "name";
            cbEstadoCor.DisplayMember = "name";
            cbCidadeCor.DataSource = endbus.listarCidades(cbEstado.SelectedValue.ToString());
            cbCidadeCor.ValueMember = "name";
            cbCidadeCor.DisplayMember = "name";

            cbEstadoCli.DataSource = endbus.listarEstados(nome);
            cbEstadoCli.ValueMember = "name";
            cbEstadoCli.DisplayMember = "name";
            cbCidadeCli.DataSource = endbus.listarCidades(cbEstado.SelectedValue.ToString());
            cbCidadeCli.ValueMember = "name";
            cbCidadeCli.DisplayMember = "name";

            cbEstadoImovel.DataSource = endbus.listarEstados(nome);
            cbEstadoImovel.ValueMember = "name";
            cbEstadoImovel.DisplayMember = "name";
            cbCidadeImovel.DataSource = endbus.listarCidades(cbEstado.SelectedValue.ToString());
            cbCidadeImovel.ValueMember = "name";
            cbCidadeImovel.DisplayMember = "name";


            cbCategoria.DataSource = catbus.listarCategorias(nome);
            cbCategoria.ValueMember = "nome";
            cbCategoria.DisplayMember = "nome";

            string nome2 = "";

            cbCategoria2.DataSource = catbus.listarCategorias(nome2);
            cbCategoria2.ValueMember = "nome";
            cbCategoria2.DisplayMember = "nome";

            cbCategoriaImovel.DataSource = catbus.listarCategorias(nome2);
            cbCategoriaImovel.ValueMember = "nome";
            cbCategoriaImovel.DisplayMember = "nome";

            dgvInteresses.DataSource = agedom.listarTodosInteressesSemVisita();
            if(agedom.listarTodosInteressesSemVisita().Count != 0)
            {
                int qtdVisitas = agedom.listarTodosInteressesSemVisita().Count;
                MessageBox.Show("Há "+ qtdVisitas +" interesse pendente !");
            }
            TimerNovosInteresses.Tick += new EventHandler(TimerNovosInteresses_Tick_1);
            TimerNovosInteresses.Interval = 120000;
            TimerNovosInteresses.Enabled = true;
            TimerNovosInteresses.Start();

            dgvUsuarios.DataSource = pesdom.listarUsuarios();

            cbPublicacao.Text = "Não Publicar";

            dgvVisitasPagamentoAluguel.DataSource = imodom.listarImoveisAluguel();

            cbDiaPagamento.Text = "1";
            cbResultadoVenda.Text = "Não realizada";

            tab.SelectedIndex = 7;

            dgvVisitas.DataSource = agedom.listarTodasVisitas();




            //falhei miseravelmente em renomear
            //int colunas = dgvUsuarios.ColumnCount - 4;
            //int linhas = dgvUsuarios.RowCount - 2;

            //for (int i = 0; i < linhas; i++)
            //{
            //    for (int j = 0; j < colunas; j++)
            //    {
            //        try
            //        {
            //            string str = dgvUsuarios[i, j].Value.ToString();
            //            if (str == "1")
            //            {
            //                dgvUsuarios[i, j].Value = "Sim";
            //            }
            //            else if (str == "0")
            //                dgvUsuarios[i, j].Value = "Não";
            //        }
            //        catch (Exception)
            //        {
            //            dgvUsuarios[i, j].Value = "Não";
                        
            //        }





            //        if (dgvUsuarios[i, j].Value.ToString() != null)
            //        {
            //            string str = dgvUsuarios[i, j].Value.ToString();
            //            if (str == "1")
            //            {
            //                dgvUsuarios[i, j].Value = "Sim";
            //            }
            //            else if (str == "0")
            //                dgvUsuarios[i, j].Value = "Não";

            //        }
            //        else
            //            dgvUsuarios[i, j].Value = "Não";






            //    }
                
            //}
        }

        private bool Validar(TabPage tab)
        {
            //if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            //{
            //    return false;
            //}
            //return true;
            //if (verifica.GetType().Equals(typeof(TextBox)))
            //if (verifica.Text == string.Empty)
            //    if (!string.IsNullOrWhiteSpace(textBox.Text))
            //    {
            //        MessageBox.Show("Preencha todos os campos !");
            //        return false;
            //    }
            foreach (Control verifica in tab.Controls)
            {

                
                if (verifica is TextBox || verifica is MaskedTextBox)
                {
                    if (verifica.Text == string.Empty)
                    {
                        MessageBox.Show("Preencha todos os campos !");
                        
                        return false;
                    }

                
                }
            }
            return true;
        }

        private void limparTextBoxEMasked(TabPage tab)//acho que funciona !
        {
            foreach (Control verifica in tab.Controls)
            {


                if (verifica is TextBox || verifica is MaskedTextBox)
                {
                    if (verifica.Text != string.Empty)
                    {
                        verifica.Text = "";
                        
                    }


                }
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Validar(tabUsuario) == true)
                {
                    pessoa pes = new pessoa();
                    usuario usu = new usuario();
                    endereco end = new endereco();
                    string nome = "";

                    PessoaBusiness pesBus = new PessoaBusiness();
                    EnderecoBusiness endbus = new EnderecoBusiness();
                    PessoaDominio pesdom = new PessoaDominio();
                    EnderecoDominio enddom = new EnderecoDominio();

                    pes.nome = txtNome.Text;
                    pes.telefone = txtTelefone.Text;
                    pes.celular = txtCelularUsu.Text;
                    pes.email = txtEmailUsu.Text;
                    pes.cpf = txtCPF.Text;
                    //agora descobrir uma forma de como saber qual tab está selecionado, falhei
                    //miseravelmente e não descobri como fazer isso, tenho que perguntar ao Octávio, pareceu saber
                    usu.usuario1 = txtLogin.Text;
                    usu.senha = txtSenha.Text;
                    end.bairro = txtBairro.Text;
                    end.logradouro = txtLogradouro.Text;
                    end.numero = Convert.ToInt16(txtNumero.Text);
                    end.cep = txtCEP.Text;
                    end.cidade = endbus.buscarIDCidade(cbCidade.Text);

                    if (pesdom.selecionarPessoacomCPF(txtCPF.Text) == null)
                    {
                        if (pesBus.SalvarPessoa(pes, usu, end) == false)
                        {
                            MessageBox.Show("Verifique o CPF !");
                        }
                        else
                        {
                            MessageBox.Show("Usuario adicionado com sucesso !");
                            ClearTextBoxes();

                            cbEstado.DataSource = endbus.listarEstados(nome);
                            cbEstado.ValueMember = "name";
                            cbEstado.DisplayMember = "name";

                            cbCidade.DataSource = endbus.listarCidades(cbEstado.SelectedValue.ToString());
                            cbCidade.ValueMember = "name";
                            cbCidade.DisplayMember = "name";
                        }
                    }
                    else
                    {
                        pessoa pesMod = pesdom.selecionarPessoacomCPF(txtCPF.Text);
                        pesMod.nome = txtNome.Text;
                        pesMod.telefone = txtTelefone.Text;
                        pesMod.celular = txtCelularUsu.Text;
                        pesMod.email = txtEmailUsu.Text;
                        pesMod.cpf = txtCPF.Text;

                        endereco endMod = enddom.selecionarEnderecoComIDPessoa(pesMod.id);
                        endMod.bairro = txtBairro.Text;
                        endMod.logradouro = txtLogradouro.Text;
                        endMod.numero = Convert.ToInt32(txtNumero.Text);
                        endMod.cep = txtCEP.Text;
                        endMod.cidade = endbus.buscarIDCidade(cbCidade.Text);

                        usuario usuMod = pesdom.selecionarObjUsuario(pesMod.id);
                        usuMod.usuario1 = txtLogin.Text;
                        usuMod.senha = txtSenha.Text;

                        pesdom.modificarUsuario(usuMod);
                        pesdom.modificarPessoa(pesMod);
                        pesdom.modificarEndereco(endMod);
                        MessageBox.Show("Usuario modificado !");
                        //ClearTextBoxes();
                        limparTextBoxEMasked(tabUsuario);

                        cbEstado.DataSource = endbus.listarEstados(nome);
                        cbEstado.ValueMember = "name";
                        cbEstado.DisplayMember = "name";

                        cbCidade.DataSource = endbus.listarCidades(cbEstado.SelectedValue.ToString());
                        cbCidade.ValueMember = "name";
                        cbCidade.DisplayMember = "name";
                    }
                }
                //else
                  //  MessageBox.Show("Preencha todos os campos !");
                

            }
            catch (Exception)
            {
                MessageBox.Show("Verifique se os campos estão preenchidos !");
                //throw;
            }
            

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvarCor_Click(object sender, EventArgs e)
        {
            try //corretor não atualizou o endereço, tem que ser verificado nos outros cadastros
            //colocar 0 para as permissões que o usuario não tem !
            {
                bool valida = Validar(tabCorretor);
                if (valida)
                {
                    pessoa pes = new pessoa();
                    corretor cor = new corretor();
                    endereco end = new endereco();
                    string nome = "";

                    PessoaBusiness pesBus = new PessoaBusiness();
                    EnderecoBusiness endbus = new EnderecoBusiness();
                    PessoaDominio pesdom = new PessoaDominio();
                    EnderecoDominio enddom = new EnderecoDominio();

                    pes.nome = txtNomeCor.Text;
                    pes.telefone = txtTelefoneCor.Text;
                    pes.cpf = txtCPFCor.Text;
                    end.bairro = txtBairroCor.Text;
                    end.logradouro = txtLogradouroCor.Text;
                    end.numero = Convert.ToInt32(txtNumeroCor.Text);
                    end.cep = txtCEPCor.Text;
                    pes.email = txtEmailCor.Text;
                    pes.celular = txtCelularCor.Text;

                    cor.vendasrealizadas = 0;
                    cor.vendasvalor = 0;
                    
                    //testar o adicionar e alterar !
                    end.cidade = endbus.buscarIDCidade(cbCidadeCor.Text);

                    if (pesdom.selecionarPessoacomCPF(txtCPFCor.Text) == null)
                    {
                        if (pesBus.SalvarPessoa(pes, cor, end, cbCategoria.Text) == false)
                        {
                            MessageBox.Show("Verifique o CPF !");
                        }
                        else
                        {
                            MessageBox.Show("Corretor adicionado com sucesso !");
                            //ClearTextBoxes();
                            limparTextBoxEMasked(tabCorretor);

                            cbEstadoCor.DataSource = endbus.listarEstados(nome);
                            cbEstadoCor.ValueMember = "name";
                            cbEstadoCor.DisplayMember = "name";
                            cbCidadeCor.DataSource = endbus.listarCidades(cbEstado.SelectedValue.ToString());
                            cbCidadeCor.ValueMember = "name";
                            cbCidadeCor.DisplayMember = "name";
                        }
                    }
                    else
                    {
                        pessoa pesMod = pesdom.selecionarPessoacomCPF(txtCPFCor.Text);
                        pesMod.nome = txtNomeCor.Text;
                        pesMod.telefone = txtTelefoneCor.Text;
                        pesMod.celular = txtCelularCor.Text;
                        pesMod.email = txtEmailCor.Text;
                        pesMod.cpf = txtCPFCor.Text;

                        endereco endMod = enddom.selecionarEnderecoComIDPessoa(pesMod.id);
                        endMod.bairro = txtBairroCor.Text;
                        endMod.logradouro = txtLogradouroCor.Text;
                        endMod.numero = Convert.ToInt32(txtNumeroCor.Text);
                        endMod.cep = txtCEPCor.Text;
                        endMod.cidade = endbus.buscarIDCidade(cbCidadeCor.Text);
                        
                        
                        pesdom.modificarPessoa(pesMod);
                        pesdom.modificarEndereco(endMod);
                        MessageBox.Show("Corretor modificado !");
                        //ClearTextBoxes();
                        limparTextBoxEMasked(tabCorretor);
                    }
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Verifique se os campos estão preenchidos !");
                //MessageBox.Show("Verifique se os campos estão preenchidos corretamente !");
                //throw;
            }
        }

        private void btnSalvarCli_Click(object sender, EventArgs e)
        {
            try//agora é ver o que tem de ruim no cliente
            {
                bool valida = Validar(tabCliente);
                if (valida)
                {
                    pessoa pes = new pessoa();
                    cliente cli = new cliente();
                    endereco end = new endereco();
                    string nome = "";

                    PessoaBusiness pesBus = new PessoaBusiness();
                    EnderecoBusiness endbus = new EnderecoBusiness();

                    pes.nome = txtNomeCli.Text;
                    pes.telefone = txtTelefoneCli.Text;
                    pes.cpf = txtCPFCli.Text;
                    pes.email = txtEmailCli.Text;
                    pes.celular = txtCelularCli.Text;
                    
                    end.bairro = txtBairroCli.Text;
                    end.logradouro = txtLogradouroCli.Text;
                    end.numero = Convert.ToInt32(txtNumeroCli.Text);
                    end.cep = txtCEPCli.Text;
                    
                    end.cidade = endbus.buscarIDCidade(cbCidadeCli.Text);


                    if (pesBus.SalvarPessoa(pes, cli, end) == false)
                    {
                        MessageBox.Show("Verifique o CPF !");
                    }
                    else
                    {
                        MessageBox.Show("Cliente adicionado/modificado com sucesso !");
                        //ClearTextBoxes();
                        limparTextBoxEMasked(tabCliente);

                        cbEstadoCli.DataSource = endbus.listarEstados(nome);
                        cbEstadoCli.ValueMember = "name";
                        cbEstadoCli.DisplayMember = "name";
                        cbCidadeCli.DataSource = endbus.listarCidades(cbEstado.SelectedValue.ToString());
                        cbCidadeCli.ValueMember = "name";
                        cbCidadeCli.DisplayMember = "name";
                    }
                        
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Verifique se os campos estão preenchidos corretamente !");
                //throw;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtNumeroCor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtNumeroCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdicionarEsp_Click(object sender, EventArgs e)
        {
            if (iddocorretor != 0)
            {
                //fazer validação para não adicionar duas especializações iguais
                PessoaDominio pesdom = new PessoaDominio();
                PessoaBusiness pesbus = new PessoaBusiness();
                if (pesbus.SalvarNovaEspecializacao(txtCPFCor.Text, cbCategoria.Text) == true)
                {
                    dgvCategoriaDoCorretor.DataSource = pesdom.listarCategoriasDoCorretor(iddocorretor);
                }
                else
                    MessageBox.Show("Especialização já adicionada ao corretor selecionado !");
            }
            else
                MessageBox.Show("Selecione um corretor !");
        }

        private void btnSelecionarUsuario_Click(object sender, EventArgs e)
        {
            PessoaBusiness pesbus = new PessoaBusiness();
            pessoa pes = new pessoa();
            endereco end = new endereco();
            EnderecoBusiness endbus = new EnderecoBusiness();
            EnderecoDominio enddom = new EnderecoDominio();
            UsuarioModel usu = new UsuarioModel();
            PessoaDominio pesdom = new PessoaDominio();

            if (txtCPF.Text != "")
            { //continuar a colocar os outros campos da pessoa ! Como Endereco além dos dados pessoais !
                if (pesbus.retornarPessoaPorCPF(txtCPF.Text) != null)
                {
                    pes = pesbus.retornarPessoaPorCPF(txtCPF.Text);
                    end = endbus.retornarEnderecoPorID(pes.idendereco.Value);
                    usu = pesdom.selecionarUsuObj(pes.id);


                    txtNome.Text = pes.nome;
                    txtEmailUsu.Text = pes.email;
                    txtTelefone.Text = pes.telefone;
                    txtCelularUsu.Text = pes.celular;
                    txtCPF.Text = pes.cpf;
                    txtLogradouro.Text = end.logradouro;
                    txtNumero.Text = end.numero.ToString();
                    txtBairro.Text = end.bairro;
                    txtCEP.Text = end.cep;
                    txtLogin.Text = usu.usuario;
                    txtSenha.Text = usu.senha;



                    //cbEstado.DataSource = enddom.selecionarEstadoEnganar(end.cidade);
                    //cbEstado.ValueMember = "name";
                    //cbEstado.DisplayMember = "name";

                    //cbCidade.DataSource = enddom.selecionarCidadeEnganar(end.cidade);
                    //cbCidade.ValueMember = "name";
                    //cbCidade.DisplayMember = "name";

                    //cbEstadoCli.DataSource = enddom.selecionarEstadoEnganar(end.cidade);
                    cbEstado.DataSource = enddom.listarTodosEstados();
                    cbEstado.SelectedValue = enddom.pegarNomeEstadoInt(end.cidade);
                    cbEstado.ValueMember = "name";
                    cbEstado.DisplayMember = "name";

                    //cbCidadeCli.DataSource = enddom.listarTodasCidades(end.cidade);
                    cbCidade.DataSource = enddom.listarCidadesTodas(enddom.pegarNomeEstadoInt(end.cidade));
                    cbCidade.SelectedValue = enddom.pegarNomeCidade(end.cidade);
                    cbCidade.ValueMember = "name";
                    cbCidade.DisplayMember = "name";
                }
                else
                    MessageBox.Show("O CPF informado não encontrou nenhum resultado cadastrado !");
                
            }
            else
                MessageBox.Show("Informe o CPF para a pesquisa !");
        }

        private void selecionarCorretor_Click(object sender, EventArgs e)
        {
            if (txtCPFCor.Text != "")
            {
                PessoaBusiness pesbus = new PessoaBusiness();
                if (pesbus.retornarPessoaPorCPF(txtCPFCor.Text) != null)
                {
                    
                    pessoa pes = new pessoa();
                    endereco end = new endereco();
                    EnderecoBusiness endbus = new EnderecoBusiness();
                    EnderecoDominio enddom = new EnderecoDominio();
                    PessoaDominio pesdom = new PessoaDominio();
                    corretor cor = new corretor();

                    cor = pesdom.selecionarCorretorcomCPF(txtCPFCor.Text);
                    pes = pesbus.retornarPessoaPorCPF(txtCPFCor.Text);
                    end = endbus.retornarEnderecoPorID(pes.idendereco.Value);
                    

                    txtNomeCor.Text = pes.nome;
                    txtEmailCor.Text = pes.email;
                    txtTelefoneCor.Text = pes.telefone;
                    txtCelularCor.Text = pes.celular;//continuar isso
                    txtCPFCor.Text = pes.cpf;
                    txtLogradouroCor.Text = end.logradouro;
                    txtNumeroCor.Text = end.numero.ToString();
                    txtBairroCor.Text = end.bairro;
                    txtCEPCor.Text = end.cep;

                    dgvCategoriaDoCorretor.DataSource = pesdom.listarCategoriasDoCorretor(pesdom.selecionarCorretorcomCPF(txtCPFCor.Text).id);


                    //cbEstadoCor.DataSource = enddom.selecionarEstadoEnganar(end.cidade);
                    //cbEstadoCor.ValueMember = "name";
                    //cbEstadoCor.DisplayMember = "name";

                    //cbCidadeCor.DataSource = enddom.selecionarCidadeEnganar(end.cidade);
                    //cbCidadeCor.ValueMember = "name";
                    //cbCidadeCor.DisplayMember = "name";


                    //cbEstadoCli.DataSource = enddom.selecionarEstadoEnganar(end.cidade);
                    cbEstadoCor.DataSource = enddom.listarTodosEstados();
                    cbEstadoCor.SelectedValue = enddom.pegarNomeEstadoInt(end.cidade);
                    cbEstadoCor.ValueMember = "name";
                    cbEstadoCor.DisplayMember = "name";

                    //cbCidadeCli.DataSource = enddom.listarTodasCidades(end.cidade);
                    cbCidadeCor.DataSource = enddom.listarCidadesTodas(enddom.pegarNomeEstadoInt(end.cidade));
                    cbCidadeCor.SelectedValue = enddom.pegarNomeCidade(end.cidade);
                    cbCidadeCor.ValueMember = "name";
                    cbCidadeCor.DisplayMember = "name";



                    txtNomeCorretor.Text = pes.nome;
                    txtCPFCorretor.Text = pes.cpf;
                    txtTelefoneCorretor.Text = pes.telefone;

                    iddocorretor = cor.id;//pesbus.selecionarCorretor(pes).id;
                }
                else
                    MessageBox.Show("O CPF informado não encontrou nenhum resultado cadastrado !");

            }
            else
                MessageBox.Show("Informe o CPF do Corretor !");
            
        }

        private void selecionarCliente_Click(object sender, EventArgs e)
        {
            if (txtCPFCli.Text != "")
            {
                PessoaBusiness pesbus = new PessoaBusiness();
                EnderecoDominio enddom = new EnderecoDominio();
                EnderecoBusiness endbus = new EnderecoBusiness();
                endereco end = new endereco();
                pessoa pes = new pessoa();



                pes = pesbus.retornarPessoaPorCPF(txtCPFCli.Text);
                end = endbus.retornarEnderecoPorID(pes.idendereco.Value);

                

                txtNomeCli.Text = pes.nome;
                txtEmailCli.Text = pes.email;
                txtTelefoneCli.Text = pes.telefone;
                txtCelularCli.Text = pes.celular;

                txtLogradouroCli.Text = end.logradouro;
                txtCEPCli.Text = end.cep;
                txtNumeroCli.Text = end.numero.ToString();
                txtBairroCli.Text = end.bairro;

                //cbEstadoCli.DataSource = enddom.selecionarEstadoEnganar(end.cidade);
                cbEstadoCli.DataSource = enddom.listarTodosEstados();
                cbEstadoCli.SelectedValue = enddom.pegarNomeEstadoInt(end.cidade);
                cbEstadoCli.ValueMember = "name";
                cbEstadoCli.DisplayMember = "name";

                //cbCidadeCli.DataSource = enddom.listarTodasCidades(end.cidade);
                cbCidadeCli.DataSource = enddom.listarCidadesTodas(enddom.pegarNomeEstadoInt(end.cidade));
                cbCidadeCli.SelectedValue = enddom.pegarNomeCidade(end.cidade);
                cbCidadeCli.ValueMember = "name";
                cbCidadeCli.DisplayMember = "name";

                
                txtTelefoneCliente.Text = pes.telefone;
                txtNomeCliente.Text = pes.nome;
                txtCPFCliente.Text = pes.cpf;

                iddocliente = pesbus.selecionarCliente(pes).id;
            }
            else
                MessageBox.Show("Informe o CPF do Cliente !");
            
        }

        private void cbEstadoCor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EnderecoBusiness endbus = new EnderecoBusiness();

            cbCidadeCor.DataSource = endbus.listarCidades(cbEstadoCor.SelectedValue.ToString());
            cbCidadeCor.ValueMember = "name";
            cbCidadeCor.DisplayMember = "name";
        }

        private void cbEstadoCli_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            EnderecoBusiness endbus = new EnderecoBusiness();

            cbCidadeCli.DataSource = endbus.listarCidades(cbEstadoCli.SelectedValue.ToString());
            cbCidadeCli.ValueMember = "name";
            cbCidadeCli.DisplayMember = "name";
        }
        private void cbEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EnderecoBusiness endbus = new EnderecoBusiness();

            cbCidade.DataSource = endbus.listarCidades(cbEstado.SelectedValue.ToString());
            cbCidade.ValueMember = "name";
            cbCidade.DisplayMember = "name";
        }

        private void dgvCorretores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dgvCorretores.CurrentRow.Cells[0].Value;
            PessoaBusiness pesbus = new PessoaBusiness();
            CorretorModel corretor =  pesbus.selecionarCorretor(id);


            txtEmailCor.Text = corretor.email;
            txtBairroCor.Text = corretor.bairro;
            txtCelularCor.Text = corretor.celular;
            txtCEPCor.Text = corretor.CEP;
            txtCPFCor.Text = corretor.CPF;
            txtLogradouroCor.Text = corretor.logradouro;
            txtTelefoneCor.Text = corretor.telefone;
            txtNumeroCor.Text = corretor.numero.ToString();
            txtNomeCor.Text = corretor.Nome;
            txtNomeCorretor.Text = corretor.Nome;
            txtCPFCorretor.Text = corretor.CPF;
            txtTelefoneCorretor.Text = corretor.telefone;
            iddocorretor = id;

            cbCidadeCor.Text = corretor.cidade;
            cbEstadoCor.Text = corretor.estado;

        }

        private void cbCategoria2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ImovelBusiness cat = new ImovelBusiness();

            //cbCategorias.DataSource = cat.listarCategorias(cbCategorias.SelectedValue.ToString());
            //cbCategorias.ValueMember = "name";
            //cbCategorias.DisplayMember = "name";
            PessoaBusiness cor = new PessoaBusiness();
            List<PessoaCorretorModel> peslist = new List<PessoaCorretorModel>();
            //pessoa pes = cor.retornarPessoaPorCPF();
            peslist = cor.listarCorretoresPorCategoria(cbCategoria2.SelectedValue.ToString());
            //como pegar o cpf quando o cara selecionar
            dgvCorretores.DataSource = peslist;
        }

        private void btnBuscarImovel_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            bool valida = Validar(tabAgendamento);
            AgendaDominio aged = new AgendaDominio();
            if (valida)
            {
                if (iddocliente != 0 && iddocorretor != 0 && iddoimovel != 0)
                {
                    if (aged.verificarDisponibilidadeImovel(cbHoraAgenda.Text, dateTimePicker2.Value.Date, iddoimovel) == true)
                    {
                        if (aged.verificarDisponibilidadeCliente(cbHoraAgenda.Text, dateTimePicker2.Value.Date, iddocliente) == true)
                        {
                            AgendaBusiness agebus = new AgendaBusiness();
                            AgendaDominio agedom = new AgendaDominio();
                            interesse inte = new interesse();
                            visita vis = new visita();
                            vis.idcliente = iddocliente;
                            vis.idimovel = iddoimovel;
                            vis.idcorretor = iddocorretor;
                            vis.data = dateTimePicker2.Value.Date;
                            vis.hora = cbHoraAgenda.Text;
                            vis.resultado = "Pendente";
                            vis.status = "Pendente";
                            vis.corretorcomissao = decimal.Parse(txtComissao.Text);
                            agebus.AdicionarAgendamento(vis);
                            inte = agedom.selecionarInteresseComID(iddointeresse);
                            inte.status = "Visita marcada";
                            agedom.modificarStatusInteresse(inte);

                            iddocliente = 0;
                            iddocorretor = 0;
                            iddoimovel = 0;
                            iddointeresse = 0;
                            //ClearTextBoxes();
                            dgvInteresses.DataSource = agedom.listarTodosInteressesSemVisita();
                            limparTextBoxEMasked(tabAgendamento);
                            limparTextBoxEMasked(tabImovel);
                            limparTextBoxEMasked(tabCorretor);
                            limparTextBoxEMasked(tabCliente);
                            MessageBox.Show("Agendamento Marcado");
                        }
                        else
                            MessageBox.Show("O cliente já tem compromisso nesse mesmo horário !");
                        
                    }
                    else
                        MessageBox.Show("O imovel não está disponivel para a data/hora selecionada !");
                    

                }
                else
                    MessageBox.Show("Tenha certeza de ter escolhido um cliente, um corretor e um imóvel !");
            }
        }

        private void btnSelecionarImovel_Click(object sender, EventArgs e)
        {
            ImovelBusiness imobus = new ImovelBusiness();
            ImovelProprietarioModel imomodel = new ImovelProprietarioModel();
            EnderecoDominio enddom = new EnderecoDominio();

            
            if(iddoimovel != 0)
            {
                imomodel = imobus.retornarImovelComProprietario(iddoimovel);

                txtNomeProprietario.Text = imomodel.nomeproprietario;
                txtCPFProprietario.Text = imomodel.CPFProprietario;
                txtQtdQuartos.Text = imomodel.qtdquartos.ToString();
                txtAreaConst.Text = imomodel.areacon;
                txtAreaTotal.Text = imomodel.areater;
                txtLogradouroImovel.Text = imomodel.logradouro;
                //cbCidadeImovel.Text = imomodel.cidade;
                txtValorImovel.Text = imomodel.valor.ToString();
                txtValorVendaImovel.Text = imomodel.valorvenda.ToString();
                cbCategoriaImovel.Text = imomodel.categoria;
                //cbEstadoImovel.Text = imomodel.estado;
                txtBairroImovel.Text = imomodel.bairro;
                txtCEPImovel.Text = imomodel.CEP;
                txtNumeroImovel.Text = imomodel.numero.ToString();
                cbFinalidadeImovel.Text = imomodel.finalidade;
                cbPublicacao.Text = imomodel.publicacao;

                txtLogradouroAgenda.Text = imomodel.logradouro;
                txtNumeroAgenda.Text = imomodel.numero.ToString();
                txtValor.Text = imomodel.valor.ToString();
                //txtValorTeste.Text = imomodel.valor.ToString();

                idcategoriaimovel = imomodel.idcatimovel;



                
                cbEstadoImovel.DataSource = enddom.listarTodosEstados();
                cbEstadoImovel.SelectedValue = imomodel.estado;
                cbEstadoImovel.ValueMember = "name";
                cbEstadoImovel.DisplayMember = "name";

                
                cbCidadeImovel.DataSource = enddom.listarCidadesTodas(imomodel.estado);
                cbCidadeImovel.SelectedValue = imomodel.cidade;
                cbCidadeImovel.ValueMember = "name";
                cbCidadeImovel.DisplayMember = "name";
                //cruzar as informações das horas livres daquele imóvel e mostrar elas na tela do corretor, com esse cruzamento terá que aparecer apenas os horarios que estão livres para os corretores e para o imóvel
            }
            MessageBox.Show("Busque por um endereço !");
        }

        private void btnSelecionarDataHorario_Click(object sender, EventArgs e)
        {
            if (cbHoraAgenda.Text != "")
            {
                AgendaDominio imobus = new AgendaDominio();
                //dando erro essa merda, tentar corrigir amanhã
                //dgvCorretores.DataSource = imobus.listarCorretoresComHorarioLivre(cbHoraAgenda.SelectedItem.ToString(), dateTimePicker2.Value.Date,idcategoriaimovel);
                dgvCorretorAgenda.DataSource = imobus.listarCorretoresPelaCategoria(idcategoriaimovel);

            }
            else
                MessageBox.Show("Selecione um horário");
        }

        private void btnSelecionarAgendamento_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvarImovel_Click(object sender, EventArgs e)
        {
            ImovelDominio imod = new ImovelDominio();
            if(iddoimovel != 0)
            {
                if (decimal.Parse(txtValorImovel.Text) < decimal.Parse(txtValorVendaImovel.Text))
                {
                    imovel imo = imod.SelecionarImovel(iddoimovel);
                    imo.valor = decimal.Parse(txtValorImovel.Text);
                    imo.valorvendalocacao = decimal.Parse(txtValorVendaImovel.Text);
                    imo.publicacaostatus = cbPublicacao.Text;
                    imod.modificarImovel(imo);

                    MessageBox.Show("Imovel Modificado !");
                    limparTextBoxEMasked(tabImovel);
                }
                else
                    MessageBox.Show("O valor pedido não pode ser maior que o valor de venda !");
                
            }
            else if(iddocliente != 0 && nomeimagem1 != "" && nomeimagem2 != "" && nomeimagem3 != "" && nomeimagem4 != "" && Validar(tabImovel) == true)
            {
                EnderecoDominio enddom = new EnderecoDominio();
                ImovelDominio imodom = new ImovelDominio();
                endereco end = new endereco();
                imovel imo = new imovel();
                string nome = "";
                EnderecoBusiness endbus = new EnderecoBusiness();

                end.logradouro = txtLogradouroImovel.Text;
                end.numero = int.Parse(txtNumeroImovel.Text);
                end.cidade = enddom.pegarIDCidade(cbCidadeImovel.Text);
                end.bairro = txtBairroImovel.Text;
                end.cep = txtCEPImovel.Text;
                enddom.AdicionarEndereco(end);

                imo.idendereco = enddom.selecionarUltimoEnderecoID(end);
                imo.idcategoria = imodom.pegarIDCategoria(cbCategoriaImovel.Text);
                imo.finalidade = cbFinalidadeImovel.Text;
                imo.areacon = txtAreaConst.Text;
                imo.areater = txtAreaTotal.Text;
                imo.qtdquartos = int.Parse(txtQtdQuartos.Text);
                imo.valor = decimal.Parse(txtValorImovel.Text);
                imo.valorvendalocacao = decimal.Parse(txtValorVendaImovel.Text);
                imo.idproprietario = iddocliente;
                imo.publicacaostatus = cbPublicacao.Text;


            //    File1 = null;
              //  File2 = null;
                //File3 = null;
                //File4 = null;
                imodom.adicionarImovel(imo);
                //openFileDialog1.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                //DialogResult result = this.openFileDialog1.ShowDialog();
                //if (result == DialogResult.OK)
                //{
                //    FileInfo file = new FileInfo(openFileDialog1.FileName);


                //    //esses dois abaixo funcionam !!!!!
                //    //string anotherpath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\SiteImo\imoveis\";
                //    //string path2 = System.IO.Path.GetFullPath(@"..\..\" + @"\SiteImo\imoveis\");


                //    string path2 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + file.Name);
                //    file.CopyTo(@path2);

                //    imo.imagem1 = file.Name;
                //    imodom.adicionarImagemAoImovel(imo);

                //}

                imo.imagem1 = nomeimagem1;
                imo.imagem2 = nomeimagem2;
                imo.imagem3 = nomeimagem3;
                imo.imagem4 = nomeimagem4;

                file1.CopyTo(@caminhoImage1);
                file2.CopyTo(@caminhoImage2);
                file3.CopyTo(@caminhoImage3);
                file4.CopyTo(@caminhoImage4);

                imodom.adicionarImagemAoImovel(imo);



                iddocliente = 0;
                nomeimagem1 = "";
                nomeimagem2 = "";
                nomeimagem3 = "";
                nomeimagem4 = "";
                //ClearTextBoxes();
                MessageBox.Show("Imovel Cadastrado !");
                limparTextBoxEMasked(tabImovel);

                cbEstadoImovel.DataSource = endbus.listarEstados(nome);
                cbEstadoImovel.ValueMember = "name";
                cbEstadoImovel.DisplayMember = "name";
                cbCidadeImovel.DataSource = endbus.listarCidades(cbEstado.SelectedValue.ToString());
                cbCidadeImovel.ValueMember = "name";
                cbCidadeImovel.DisplayMember = "name";

            }
            else
                MessageBox.Show("Verifique se os campos estão preenchidos e se as 4 imagens foram selecionadas !!");
        }

        private void button4_Click(object sender, EventArgs e)//é o botão de buscar abaixo do proprietario da tap imovel
        {
            if (txtCPFProprietario.Text != "")
            {
                if (validarCPF(txtCPFProprietario.Text) == true)
                {
                    PessoaDominio pesdom = new PessoaDominio();
                    pessoa pes = pesdom.selecionarPessoacomCPF(txtCPFProprietario.Text);
                    txtNomeProprietario.Text = pes.nome;
                    iddocliente = pesdom.selecionarCliente(pes).id;
                }
                else
                    MessageBox.Show("Informe um CPF valido !");
                
            }
            else
                MessageBox.Show("Informe o CPF do proprietário !");
            
        }

        private void btnImagem1_Click(object sender, EventArgs e)
        {//tentar arranjar uma forma de validar o nome da imagem com o que estiver na pasta
            openFileDialog1.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ImovelDominio imodom = new ImovelDominio();
            int idimovel = imodom.SelecionarUltimoImovel().id;
            string iddoimovel = (idimovel + 1).ToString();
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                file1 = new FileInfo(openFileDialog1.FileName);
                caminhoImage1 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + file1.Name);

                if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), caminhoImage1)))//será que isso deu certo ?
                {
                    int i = 1;
                    caminhoImage1 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + iddoimovel + file1.Name);//agora vai

                    nomeimagem1 = iddoimovel + file1.Name;
                    while (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), caminhoImage1)))
                    {
                        caminhoImage1 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + iddoimovel + i + file1.Name);
                        nomeimagem1 = iddoimovel + i + file1.Name;
                        i++;
                    }
                    lblImg1.Text = "Imagem selecionada";
                    //pega o ID que estaria no imovel adicionado e sempre colocar ele antes de cada imagem adicionada, nunca terá o ID no inicio
                    //igual !


                    //solução mais tosca
                    //MessageBox.Show("Informe outro nome para a imagem !");
                    //caminhoImage1 = "";
                }
                else
                {
                    nomeimagem1 = file1.Name;
                    lblImg1.Text = "Imagem 1 selecionada";
                }
                    

                
            }
        }

        private void btnImagem2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ImovelDominio imodom = new ImovelDominio();
            int idimovel = imodom.SelecionarUltimoImovel().id;
            string iddoimovel = (idimovel + 1).ToString();
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                file2 = new FileInfo(openFileDialog1.FileName);
                caminhoImage2 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + file2.Name);

                if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), caminhoImage2)))//será que isso deu certo ?
                {
                    int i = 1;
                    caminhoImage2 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + iddoimovel + file2.Name);//agora vai

                    nomeimagem2 = iddoimovel + file2.Name;
                    while (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), caminhoImage2)))
                    {
                        caminhoImage2 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + iddoimovel + i + file2.Name);
                        nomeimagem2 = iddoimovel + i + file2.Name;
                        i++;
                    }
                    lblImg2.Text = "Imagem selecionada";
                    //pega o ID que estaria no imovel adicionado e sempre colocar ele antes de cada imagem adicionada, nunca terá o ID no inicio
                    //igual !


                    //solução mais tosca
                    //MessageBox.Show("Informe outro nome para a imagem !");
                    //caminhoImage1 = "";
                }
                else
                {
                    nomeimagem2 = file2.Name;
                    lblImg2.Text = "Imagem selecionada";
                }



            }






            //if (result == DialogResult.OK)
            //{
            //    file2 = new FileInfo(openFileDialog1.FileName);
            //    caminhoImage2 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + file2.Name);
            //    nomeimagem2 = file2.Name;

            //    lblImg2.Text = "Imagem 2 selecionada";
            //}
        }

        private void btnImagem3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ImovelDominio imodom = new ImovelDominio();
            int idimovel = imodom.SelecionarUltimoImovel().id;
            string iddoimovel = (idimovel + 1).ToString();
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                file3 = new FileInfo(openFileDialog1.FileName);
                caminhoImage3 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + file3.Name);

                if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), caminhoImage3)))//será que isso deu certo ?
                {
                    int i = 1;
                    caminhoImage3 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + iddoimovel + file3.Name);//agora vai

                    nomeimagem3 = iddoimovel + file3.Name;
                    while (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), caminhoImage3)))
                    {
                        caminhoImage3 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + iddoimovel + i + file3.Name);
                        nomeimagem3 = iddoimovel + i + file3.Name;
                        i++;
                    }
                    lblImg3.Text = "Imagem selecionada";
                    //pega o ID que estaria no imovel adicionado e sempre colocar ele antes de cada imagem adicionada, nunca terá o ID no inicio
                    //igual !


                    //solução mais tosca
                    //MessageBox.Show("Informe outro nome para a imagem !");
                    //caminhoImage1 = "";
                }
                else
                {
                    nomeimagem3 = file3.Name;
                    lblImg3.Text = "Imagem selecionada";
                }



            }













            //if (result == DialogResult.OK)
            //{
            //    file3 = new FileInfo(openFileDialog1.FileName);
            //    caminhoImage3 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + file3.Name);

            //    nomeimagem3 = file3.Name;

            //    lblImg3.Text = "Imagem 3 selecionada";
            //}
        }

        private void btnImagem4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ImovelDominio imodom = new ImovelDominio();
            int idimovel = imodom.SelecionarUltimoImovel().id;
            string iddoimovel = (idimovel + 1).ToString();
            DialogResult result = this.openFileDialog1.ShowDialog();


            if (result == DialogResult.OK)
            {
                file4 = new FileInfo(openFileDialog1.FileName);
                caminhoImage4 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + file4.Name);

                if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), caminhoImage4)))//será que isso deu certo ?
                {
                    int i = 1;
                    caminhoImage4 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + iddoimovel + file4.Name);//agora vai

                    nomeimagem4 = iddoimovel + file4.Name;
                    while (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), caminhoImage4)))
                    {
                        caminhoImage4 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + iddoimovel + i + file4.Name);
                        nomeimagem4 = iddoimovel + i + file4.Name;
                        i++;
                    }
                    lblImg4.Text = "Imagem selecionada";
                    //pega o ID que estaria no imovel adicionado e sempre colocar ele antes de cada imagem adicionada, nunca terá o ID no inicio
                    //igual !


                    //solução mais tosca
                    //MessageBox.Show("Informe outro nome para a imagem !");
                    //caminhoImage1 = "";
                }
                else
                {
                    nomeimagem4 = file4.Name;
                    lblImg4.Text = "Imagem selecionada";
                }



            }



            //if (result == DialogResult.OK)
            //{
            //    file4 = new FileInfo(openFileDialog1.FileName);
            //    caminhoImage4 = System.IO.Path.GetFullPath(@"..\..\..\" + @"\SiteImo\imoveis\" + file4.Name);

            //    nomeimagem4 = file4.Name;

            //    lblImg4.Text = "Imagem 4 selecionada";
            //}
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AgendaDominio agedom = new AgendaDominio();
            dgvVisitas.DataSource = agedom.listarTodasVisitas();
        }

        private void dgvVisitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dgvVisitas.CurrentRow.Cells[0].Value;
            AgendaDominio agedom = new AgendaDominio();
            PessoaDominio pesdom = new PessoaDominio();
            ImovelDominio imodom = new ImovelDominio();
            visita visita = agedom.selecionarVisitaComID(id);
            CorretorModel cor = pesdom.selecionarCorretor(visita.idcorretor.Value);
            pessoa cli = pesdom.selecionarPessoaComIDCliente(visita.idcliente.Value);
            imovel imo = imodom.SelecionarImovel(visita.idimovel.Value);

            txtCorretorVenda.Text = cor.Nome;
            txtClienteVenda.Text = cli.nome;
            cbStatusPagamentoVenda.Text = visita.status;
            cbResultadoVenda.Text = visita.resultado;
            txtComissaoCorretorVenda.Text = visita.corretorcomissao.ToString();
            txtFinalidadeVenda.Text = imo.finalidade;
            if(imo.finalidade == "Venda")
            {
                label90.Visible = false;
                cbDiaPagamento.Visible = false;
            }
            else
            {                
                label90.Visible = true;
                cbDiaPagamento.Visible = true;
            }
            idvisita = visita.id;
            
            
            //fazer com que pelo retorno da finalidade, libere campo txt para marca o dia de pagamento
            // para o caso de aluguel e o valor a ser pago, que se encontra no imovel também, logo terei que fazer um
            //visita.imovel.valorvendaaluguel;
        }

        private void btnSalvarVenda_Click(object sender, EventArgs e)
        {
            int id = 0;

            if (dgvVisitas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma visita !");
            }
            else
            {
                id = (int)dgvVisitas.CurrentRow.Cells[0].Value;
                AgendaDominio agedom = new AgendaDominio();
                PessoaDominio pesdom = new PessoaDominio();
                ImovelDominio imodom = new ImovelDominio();
                visita visita = agedom.selecionarVisitaComID(id);
                CorretorModel cor = pesdom.selecionarCorretor(visita.idcorretor.Value);
                corretor corre = new corretor();
                pessoa cli = pesdom.selecionarPessoaComIDCliente(visita.idcliente.Value);
                imovel imo = imodom.SelecionarImovel(visita.idimovel.Value);
                cliente c = pesdom.selecionarClienteComIDPessoa(cli.id);
                //selecionar venda para ver se já não foi vendido
                //selecionar aluguel para ver se não foi vendido
                if (idvisita != 0)
                {
                    //AgendaDominio agedom = new AgendaDominio();
                    //vendas ven = new vendas();
                    //ven.datav = DateTime.Now.Date;
                    //ven.corretorcomissao = decimal.Parse(txtComissaoCorretorVenda.Text);
                    //ven.status = cbStatusPagamentoVenda.Text;
                    //ven.idvisita = idvisita;
                    //agedom.adicionarVenda(ven);
                    //idvisita = 0;
                    if (cbResultadoVenda.Text == "Realizada")
                    {
                        if (txtFinalidadeVenda.Text == "Aluguel")
                        {

                            cbDiaPagamento.Visible = true;//aqui vou seguir a sequencia para adicionar o aluguel
                            locacoes aluguel = new locacoes();
                            aluguel.diapagamento = cbDiaPagamento.Text;
                            aluguel.datalocacao = DateTime.Now.Date;
                            aluguel.status = cbStatusPagamentoVenda.Text;
                            aluguel.idvisita = idvisita;

                            //adicionar o pagamento, a regra de negócio é o cara pagar na hora também !
                            pagamentos pagamento = new pagamentos();
                            pagamento.valor = imo.valorvendalocacao;
                            pagamento.datap = aluguel.datalocacao;
                            //trazer ultima locação
                            pagamento.idlocacoes = agedom.adicionarAluguelRetornaID(aluguel);
                            agedom.adicionarPagamento(pagamento);
                            visita.resultado = "Realizada";
                            visita.status = cbStatusPagamentoVenda.Text;
                            agedom.modificarStatusVisita(visita);
                            imo.publicacaostatus = "Não publicar";
                            imo.idcliente = c.id;
                            imodom.modificarStatusImovelPublicacao(imo);
                            corre = pesdom.selecionarCorretorcomCPF(cor.CPF);
                            corre.vendasrealizadas += 1;
                            corre.vendasvalor += imo.valorvendalocacao;
                            pesdom.alterarCorretorVendasAluguel(corre);
                            //ClearTextBoxes();
                            MessageBox.Show("Aluguel registrado !");
                            dgvVisitas.DataSource = agedom.listarTodasVisitas();
                            limparTextBoxEMasked(tabVenda);
                            
                        }
                        else if (txtFinalidadeVenda.Text == "Venda")
                        {
                            vendas venda = new vendas();
                            venda.idvisita = idvisita;
                            venda.datav = DateTime.Now.Date;
                            venda.status = cbStatusPagamentoVenda.Text;
                            venda.corretorcomissao = visita.corretorcomissao.Value;
                            visita.resultado = "Realizada";
                            visita.status = cbStatusPagamentoVenda.Text;
                            agedom.modificarStatusVisita(visita);
                            agedom.adicionarVenda(venda);
                            imo.publicacaostatus = "Não publicar";
                            imodom.modificarStatusImovelPublicacao(imo);
                            corre = pesdom.selecionarCorretorcomCPF(cor.CPF);
                            corre.vendasrealizadas += 1;
                            corre.vendasvalor += imo.valorvendalocacao;
                            pesdom.alterarCorretorVendasAluguel(corre);
                            //ClearTextBoxes();
                            MessageBox.Show("Venda registrada !");
                            dgvVisitas.DataSource = agedom.listarTodasVisitas();
                            limparTextBoxEMasked(tabVenda);

                        }
                        else
                            MessageBox.Show("Preencha todos os campos !");
                    }
                    else if (cbResultadoVenda.Text == "Não realizada")
                    {
                        visita.resultado = "Não realizada";
                        visita.status = "Cancelado";
                        agedom.modificarStatusVisita(visita);
                        //ClearTextBoxes();
                        dgvVisitas.DataSource = agedom.listarTodasVisitas();
                        limparTextBoxEMasked(tabVenda);
                    }
                    else
                        MessageBox.Show("Selecione algo para acontecer com essa visita !");


                }
                else
                    MessageBox.Show("Selecione a visita !");
            }


        }

        private void dgvCorretorAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dgvCorretorAgenda.CurrentRow.Cells[0].Value;
            PessoaBusiness pesbus = new PessoaBusiness();
            CorretorModel corretor = pesbus.selecionarCorretor(id);
            AgendaDominio agedom = new AgendaDominio();
            if ((agedom.verificarSeTemCompromisso(cbHoraAgenda.SelectedItem.ToString(), dateTimePicker2.Value.Date, id) == null))
            {
                txtNomeCorretor.Text = corretor.Nome;
                txtCPFCorretor.Text = corretor.CPF;
                txtTelefoneCorretor.Text = corretor.telefone;
                iddocorretor = id;
            }
            else
                //validação já esta funcionando, agora é fazer para imovel e cliente !
                MessageBox.Show("Corretor já está com compromisso, tente outro horário ou corretor !");
        }




   

        private void TimerNovosInteresses_Tick_1(object sender, EventArgs e)
        {
            AgendaDominio agedom = new AgendaDominio();
            dgvInteresses.DataSource = agedom.listarTodosInteressesSemVisita();
        }

        private void dgvInteresses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            iddointeresse = (int)dgvInteresses.CurrentRow.Cells[0].Value;
            AgendaDominio agedom = new AgendaDominio();
            PessoaDominio pesdom = new PessoaDominio();
            ImovelDominio imodom = new ImovelDominio();
            
            pessoa pes = new pessoa();
            interesse inte = agedom.selecionarInteresseComID(iddointeresse);
            imovel imo = new imovel();
            //tem que verificar se a pessoa já é cadastrada como cliente
            pes = pesdom.selecionarPessoaRetornarCPF(inte.idcliente.Value);
            cliente cli = pesdom.selecionarClienteComIDPessoa(inte.idcliente.Value);
            txtCPFCli.Text = pes.cpf;
            txtNomeCli.Text = pes.nome;
            txtTelefoneCli.Text = pes.telefone;
            txtEmailCli.Text = pes.email;

            iddocliente = cli.id;
            iddoimovel = inte.idimovel.Value;



            //selecionarCliente_Click(sender, e);
            //btnSelecionarImovel_Click(sender, e);
            

            if (pes.idendereco == null)
            {
                MessageBox.Show("O cliente do interesse selecionado ainda não teve o cadastro terminado, finalize-o antes de usa-lo para o agendamento !");
                tab.SelectedIndex = 2;
            }
            else
            {
                ImovelProprietarioModel imomodel = new ImovelProprietarioModel();
                imomodel = imodom.retornarImovelComProprietario(iddoimovel);

                txtCelularCli.Text = pes.celular;

                cbEstadoCli.Text = imomodel.estado;
                cbCidadeCli.Text = imomodel.cidade;
                txtLogradouroCli.Text = imomodel.logradouro;
                txtNumeroCli.Text = imomodel.numero.ToString();
                txtBairroCli.Text = imomodel.bairro;
                txtCEPCli.Text = imomodel.CEP;


                //agendamento

                txtNomeCliente.Text = pes.nome;
                txtCPFCliente.Text = pes.cpf;
                txtTelefoneCliente.Text = pes.telefone;

                imo = imodom.SelecionarImovel(iddoimovel);
                txtLogradouroAgenda.Text = imomodel.logradouro;
                txtNumeroAgenda.Text = imomodel.numero.ToString();
                txtCategoriaAgenda.Text = imomodel.categoria;

                idcategoriaimovel = imomodel.idcatimovel;
                txtValor.Text = imomodel.valorvenda.ToString();
                //terminar de testar o agendamento e ir para venda e aluguel !

                tab.SelectedIndex = 4;
            }

            //inte.status = "Visita marcada";
            //agedom.modificarStatusInteresse(inte);
            //dgvInteresses.DataSource = agedom.listarTodosInteressesSemVisita();
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {

        }
                       
          //  e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
          //      txtComissao.Text = (Decimal.Parse(txtValor.Text) * (Decimal.Parse(txtPorcentagem.Text) / 100)).ToString();
          //  txtComissaoTeste.Text = (Decimal.Parse(txtValorTeste.Text = txtValor.Text) * (Decimal.Parse(txtPorcentagemTeste.Text) / 100)).ToString();
         

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            PessoaDominio pesdom = new PessoaDominio();
            iddousuario = (int)dgvUsuarios.CurrentRow.Cells[0].Value;
            lblUsuarioPermissoes.Text = pesdom.pegarNomeUsuario(iddousuario).ToString();
            permissao = pesdom.listarPermissoesdoUsuario(iddousuario);
            
        }

        private void btnAdicionarPermissao_Click(object sender, EventArgs e)
        {
            int perm = cbPermissoes.SelectedIndex;
            permissoes per = new permissoes();
            PessoaDominio pesdom = new PessoaDominio();
            if (iddousuario != 0)
            {

                switch (perm)
                {
                    case 0:
                        permissao.gerenciarusuario = "1";
                        pesdom.modificarPermissao(permissao);
                        dgvUsuarios.DataSource = pesdom.listarUsuarios();
                        //iddousuario = 0;
                        //dgvUsuarios.DataSource = pesdom.listarPermissoesdoUsuario(iddousuario);
                        break;

                    case 1:
                        permissao.publicarimovel = "1";
                        pesdom.modificarPermissao(permissao);
                        dgvUsuarios.DataSource = pesdom.listarUsuarios();
                        //iddousuario = 0;
                        //dgvUsuarios.DataSource = pesdom.listarPermissoesdoUsuario(iddousuario);
                        break;

                    case 2:
                        permissao.gerenciarvisita = "1";
                        pesdom.modificarPermissao(permissao);
                        dgvUsuarios.DataSource = pesdom.listarUsuarios();
                        //iddousuario = 0;
                        //dgvUsuarios.DataSource = pesdom.listarPermissoesdoUsuario(iddousuario);
                        break;

                    case 3:
                        permissao.gerenciarvendaaluguel = "1";
                        pesdom.modificarPermissao(permissao);
                        dgvUsuarios.DataSource = pesdom.listarUsuarios();
                        //iddousuario = 0;
                        //dgvUsuarios.DataSource = pesdom.listarPermissoesdoUsuario(iddousuario);
                        break;

                    case 4:
                        permissao.gerenciarpermissoes = "1";
                        pesdom.modificarPermissao(permissao);
                        dgvUsuarios.DataSource = pesdom.listarUsuarios();
                        //iddousuario = 0;
                        //dgvUsuarios.DataSource = pesdom.listarPermissoesdoUsuario(iddousuario);
                        break;

                    case 5:
                        permissao.gerenciarpagamentoaluguel = "1";
                        pesdom.modificarPermissao(permissao);
                        dgvUsuarios.DataSource = pesdom.listarUsuarios();
                        //iddousuario = 0;
                        //dgvUsuarios.DataSource = pesdom.listarPermissoesdoUsuario(iddousuario);
                        break;

                }
            }
            else
                MessageBox.Show("Selecione um usuario !");

        }

        private void btnAlterarCor_Click(object sender, EventArgs e)
        {
            if (iddocorretor != 0)
            {
                PessoaDominio pesdom = new PessoaDominio();

                pessoa pes = new pessoa();
                corretor cor = new corretor();
                endereco end = new endereco();

                PessoaBusiness pesBus = new PessoaBusiness();
                EnderecoBusiness endbus = new EnderecoBusiness();
                EnderecoDominio enddom = new EnderecoDominio();

                pes.nome = txtNomeCor.Text;
                pes.telefone = txtTelefoneCor.Text;
                pes.celular = txtCelularCor.Text;
                pes.cpf = txtCPFCor.Text;
                pes.id = pesdom.selecionarPessoacomCPF(txtCPFCor.Text).id;
                pes.idendereco = enddom.selecionarEnderecoComRuaeNumero(txtLogradouroCor.Text,int.Parse(txtNumeroCor.Text)).id;
                pes.email = txtEmailCor.Text;


                end.id = enddom.selecionarEnderecoComRuaeNumero(txtLogradouroCor.Text, int.Parse(txtNumeroCor.Text)).id;
                end.bairro = txtBairroCor.Text;
                end.logradouro = txtLogradouroCor.Text;
                end.numero = Convert.ToInt32(txtNumeroCor.Text);
                end.cep = txtCEPCor.Text;
                end.cidade = endbus.buscarIDCidade(cbCidadeCor.Text);

                cor = pesdom.selecionarCorretor(pes);

                pesdom.alterarCorretor(pes, cor, end);
            }
            else
                MessageBox.Show("Selecione um corretor !");

            

        }

        private void btnAlterarCli_Click(object sender, EventArgs e)
        {
            if(txtCPFCli.Text != "")
            {
                PessoaDominio pesdom = new PessoaDominio();

                pessoa pes = new pessoa();
                cliente cli = new cliente();
                endereco end = new endereco();

                PessoaBusiness pesBus = new PessoaBusiness();
                EnderecoBusiness endbus = new EnderecoBusiness();
                EnderecoDominio enddom = new EnderecoDominio();

                pes.id = pesdom.selecionarPessoacomCPF(txtCPFCli.Text).id;
                pes.nome = txtNomeCli.Text;
                pes.telefone = txtTelefoneCli.Text;
                pes.cpf = txtCPFCli.Text;
                pes.email = txtEmailCli.Text;
                pes.celular = txtCelularCli.Text;
                pes.idendereco = enddom.selecionarEnderecoComRuaeNumero(txtLogradouroCli.Text, int.Parse(txtNumeroCli.Text)).id;

                end.id = enddom.selecionarEnderecoComRuaeNumero(txtLogradouroCli.Text, int.Parse(txtNumeroCli.Text)).id;
                end.bairro = txtBairroCli.Text;
                end.logradouro = txtLogradouroCli.Text;
                end.numero = Convert.ToInt32(txtNumeroCli.Text);
                end.cep = txtCEPCli.Text;
                end.cidade = endbus.buscarIDCidade(cbCidadeCli.Text);

                cli = pesdom.selecionarCliente(pes);

                pesdom.alterarCli(pes, cli, end);
            }
            
        }

        private void btnAlterarUsu_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text != "")
            {
                PessoaDominio pesdom = new PessoaDominio();

                pessoa pes = new pessoa();
                usuario usu = new usuario();
                endereco end = new endereco();

                PessoaBusiness pesBus = new PessoaBusiness();
                EnderecoBusiness endbus = new EnderecoBusiness();
                EnderecoDominio enddom = new EnderecoDominio();

                pes.nome = txtNome.Text;
                pes.telefone = txtTelefone.Text;
                pes.celular = txtCelularUsu.Text;
                pes.email = txtEmailUsu.Text;
                pes.cpf = txtCPF.Text;
                pes.id = pesdom.selecionarPessoacomCPF(txtCPF.Text).id;
                pes.idendereco = enddom.selecionarEnderecoComRuaeNumero(txtLogradouro.Text, int.Parse(txtNumero.Text)).id;

                end.id = enddom.selecionarEnderecoComRuaeNumero(txtLogradouro.Text, int.Parse(txtNumero.Text)).id;
                end.bairro = txtBairro.Text;
                end.logradouro = txtLogradouro.Text;
                end.numero = Convert.ToInt16(txtNumero.Text);
                end.cep = txtCEP.Text;
                end.cidade = endbus.buscarIDCidade(cbCidade.Text);

                usu.id = pesdom.selecionarUsu(txtLogin.Text, txtSenha.Text);
                usu.idpessoa = pesdom.selecionarPessoacomCPF(txtCPF.Text).id;
                usu.usuario1 = txtLogin.Text;
                usu.senha = txtSenha.Text;

                pesdom.alterarUsu(pes, usu, end);
            }
            else
                MessageBox.Show("Informe o CPF do Cliente !");

        }
        

        private void btnExcluirPermissao_Click(object sender, EventArgs e)
        {
            int perm = cbPermissoes.SelectedIndex;
            permissoes per = new permissoes();
            PessoaDominio pesdom = new PessoaDominio();
            if(iddousuario != 0)
            {

            
            switch (perm)
            {
                case 0:
                    permissao.gerenciarusuario = "0";
                    pesdom.modificarPermissao(permissao);
                    dgvUsuarios.DataSource = pesdom.listarUsuarios();
                    //dgvUsuarios.DataSource = pesdom.listarPermissoesdoUsuario(iddousuario);
                    break;

                case 1:
                    permissao.publicarimovel = "0";
                    pesdom.modificarPermissao(permissao);
                    dgvUsuarios.DataSource = pesdom.listarUsuarios();
                    //dgvUsuarios.DataSource = pesdom.listarPermissoesdoUsuario(iddousuario);
                    break;

                case 2:
                    permissao.gerenciarvisita = "0";
                    pesdom.modificarPermissao(permissao);
                    dgvUsuarios.DataSource = pesdom.listarUsuarios();
                    //dgvUsuarios.DataSource = pesdom.listarPermissoesdoUsuario(iddousuario);
                    break;

                case 3:
                    permissao.gerenciarvendaaluguel = "0";
                    pesdom.modificarPermissao(permissao);
                    dgvUsuarios.DataSource = pesdom.listarUsuarios();
                    //dgvUsuarios.DataSource = pesdom.listarPermissoesdoUsuario(iddousuario);
                    break;

                case 4:
                    permissao.gerenciarpermissoes = "0";
                    pesdom.modificarPermissao(permissao);
                    dgvUsuarios.DataSource = pesdom.listarUsuarios();
                    //dgvUsuarios.DataSource = pesdom.listarPermissoesdoUsuario(iddousuario);
                    break;

                case 5:
                    permissao.gerenciarpagamentoaluguel = "0";
                    pesdom.modificarPermissao(permissao);
                    dgvUsuarios.DataSource = pesdom.listarUsuarios();
                    //dgvUsuarios.DataSource = pesdom.listarPermissoesdoUsuario(iddousuario);
                    break;

            }
            }
            else
                MessageBox.Show("Informe o CPF do Cliente !");
        }

        private void btnEndereco_Click(object sender, EventArgs e)
        {
            if (txtLogradouroImovel.Text != "" && txtNumeroImovel.Text != "")
            {
                EnderecoDominio enddom = new EnderecoDominio();
                ImovelDominio imodom = new ImovelDominio();
                ImovelProprietarioModel imomodel = new ImovelProprietarioModel();
                endereco end = new endereco();
                imovel imo = new imovel();


                try
                {
                    end = enddom.selecionarEnderecoComRuaeNumero(txtLogradouroImovel.Text, int.Parse(txtNumeroImovel.Text));
                    imo = imodom.SelecionarImovelcomEndereco(end.id);
                    imomodel = imodom.retornarImovelComProprietario(imo.id);
                    txtLogradouroImovel.Text = end.logradouro;
                    txtNumeroImovel.Text = end.numero.ToString();
                    txtBairroImovel.Text = end.bairro;
                    txtCEPImovel.Text = end.cep;
                    txtValorImovel.Text = imo.valor.ToString();
                    txtValorVendaImovel.Text = imo.valorvendalocacao.ToString();
                    txtNomeProprietario.Text = imomodel.nomeproprietario;
                    txtCPFProprietario.Text = imomodel.CPFProprietario;
                    txtQtdQuartos.Text = imomodel.qtdquartos.ToString();
                    cbFinalidadeImovel.Text = imomodel.finalidade;
                    txtAreaConst.Text = imomodel.areacon;
                    txtAreaTotal.Text = imomodel.areater;
                    cbCategoriaImovel.Text = imomodel.categoria;
                    cbPublicacao.Text = imomodel.publicacao;

                    iddoimovel = imo.id;


                    cbEstadoImovel.DataSource = enddom.listarTodosEstados();
                    cbEstadoImovel.SelectedValue = imomodel.estado;
                    cbEstadoImovel.ValueMember = "name";
                    cbEstadoImovel.DisplayMember = "name";


                    cbCidadeImovel.DataSource = enddom.listarCidadesTodas(imomodel.estado);
                    cbCidadeImovel.SelectedValue = imomodel.cidade;
                    cbCidadeImovel.ValueMember = "name";
                    cbCidadeImovel.DisplayMember = "name";
                }
                catch (Exception)
                {
                    MessageBox.Show("Endereço não encontrado no banco !");
                    //throw;
                }




                

            }
            else
                MessageBox.Show("Informe o logradouro e o numero !");

            
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 2;
        }

        private void btnBuscarImovel_Click_1(object sender, EventArgs e)
        {
            tab.SelectedIndex = 3;
        }
        

        private void cbEstadoImovel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EnderecoBusiness endbus = new EnderecoBusiness();

            cbCidadeImovel.DataSource = endbus.listarCidades(cbEstadoImovel.SelectedValue.ToString());
            cbCidadeImovel.ValueMember = "name";
            cbCidadeImovel.DisplayMember = "name";
        }

        private void btnAceitarPagamento_Click(object sender, EventArgs e)
        {
            if (Validar(tabAluguel) == true)//txtCPFClientePagamento.Text != "")
            {
                ImovelDominio imodom = new ImovelDominio();
                PessoaDominio pesdom = new PessoaDominio();
                pesdom.selecionarPessoacomCPF(txtCPFClientePagamento.Text);
                pagamentos pag = new pagamentos();
                AgendaDominio agedom = new AgendaDominio();
                pag.datap = DateTime.Now;
                pag.idlocacoes = idlocacao;
                pag.valor = decimal.Parse(txtValorAluguelPagamento.Text);
                agedom.adicionarPagamento(pag);
                idlocacao = 0;
                //ClearTextBoxes();
                limparTextBoxEMasked(tabAluguel);
                dgvVisitasPagamentoAluguel.DataSource = imodom.listarImoveisAluguel();
            }
            else
                MessageBox.Show("Selecione um cliente !");
        }

        private void btnPesquisarClientePagamento_Click(object sender, EventArgs e)
        {
            if (txtCPFClientePagamento.Text != "")
            {
                PessoaDominio pesdom = new PessoaDominio();
                ImovelDominio imodom = new ImovelDominio();
                if (pesdom.selecionarPessoacomCPF(txtCPFClientePagamento.Text) != null)//validarCPF(txtCPFClientePagamento.Text) == true)
                {
                    
                    pessoa pes = new pessoa();
                    pes = pesdom.selecionarPessoacomCPF(txtCPFClientePagamento.Text);
                    txtNomeClientePagamento.Text = pes.nome;
                    //txtValorAluguelPagamento.Text = imodom.selecion
                }
                else
                    MessageBox.Show("Escreva um CPF valido !");
                
            }
            else
                MessageBox.Show("Escreva um CPF antes !");
            
            
        }

        public static bool validarCPF(string CPF)
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCPF;
            string Digito;
            int soma;
            int resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            TempCPF = CPF.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = resto.ToString();
            TempCPF = TempCPF + Digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = Digito + resto.ToString();

            return CPF.EndsWith(Digito);
        }

        private void dgvVisitasPagamentoAluguel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idImovel = (int)dgvVisitasPagamentoAluguel.CurrentRow.Cells[0].Value;
            PessoaDominio pesdom = new PessoaDominio();
            ImovelDominio imodom = new ImovelDominio();
            pessoa pes = new pessoa();
            imovel imo = new imovel();
            imo = imodom.SelecionarImovel(idImovel);
            pes = pesdom.selecionarPessoaComIDCliente(imo.idcliente.Value);

            txtCPFClientePagamento.Text = pes.cpf;
            txtNomeClientePagamento.Text = pes.nome;
            txtValorAluguelPagamento.Text = imo.valorvendalocacao.ToString();
            idlocacao = (int)dgvVisitasPagamentoAluguel.CurrentRow.Cells[4].Value;
        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarCorretor_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnSairImovel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void rbAlugueis_CheckedChanged(object sender, EventArgs e)
        {
            btnAtrasados.Visible = true;
            btnImoveis.Visible = false;
            btnFaturamento.Visible = false;
            btnCorretoresVenda.Visible = false;

            pnlLucro.Visible = false;
            pnlAlugueis.Visible = true;
        }


        private void rbLucro_CheckedChanged(object sender, EventArgs e)
        {
            btnAtrasados.Visible = false;
            btnImoveis.Visible = false;
            btnFaturamento.Visible = true;
            btnCorretoresVenda.Visible = false;

            
            pnlAlugueis.Visible = false;
            pnlLucro.Visible = true;
        }

        private void rbImoveis_CheckedChanged(object sender, EventArgs e)
        {
            btnAtrasados.Visible = false;
            btnImoveis.Visible = true;
            btnFaturamento.Visible = false;
            btnCorretoresVenda.Visible = false;

            pnlLucro.Visible = false;
            pnlAlugueis.Visible = false;
        }

        private void CorretoresVendas_CheckedChanged(object sender, EventArgs e)
        {
            btnAtrasados.Visible = false;
            btnImoveis.Visible = false;
            btnFaturamento.Visible = false;
            btnCorretoresVenda.Visible = true;

            pnlLucro.Visible = false;
            pnlAlugueis.Visible = false;

        }

        private void btnAtrasados_Click(object sender, EventArgs e)
        {
            if (txtInicialVA.Text != "")
            {
                RelatorioClienteAluguelAtrasado rpt = new RelatorioClienteAluguelAtrasado();
                rpt.SetDatabaseLogon(usuario, senha);
                rpt.SetParameterValue(0, txtInicialVA.Text);
                frmRelatorio rel = new frmRelatorio();
                rel.crystalReportViewer1.ReportSource = rpt;
                rel.ShowDialog();
                rel = null;
                rpt = null;
            }
            else
                MessageBox.Show("Informe as datas ?");

        }
        private void btnImoveis_Click(object sender, EventArgs e)
        {
            RelatorioRelacaoImoveis rpt = new RelatorioRelacaoImoveis();
            rpt.SetDatabaseLogon(usuario, senha);
            frmRelatorio rel = new frmRelatorio();
            rel.crystalReportViewer1.ReportSource = rpt;
            rel.ShowDialog();
            rel = null;
            rpt = null;
        }

        private void btnCorretoresVenda_Click(object sender, EventArgs e)
        {
            ListarCorretoresEVendas rpt = new ListarCorretoresEVendas();
            rpt.SetDatabaseLogon(usuario, senha);
            frmRelatorio rel = new frmRelatorio();
            rel.crystalReportViewer1.ReportSource = rpt;
            rel.ShowDialog();
            rel = null;
            rpt = null;
        }

        private void btnFaturamento_Click(object sender, EventArgs e)
        {
            RelatorioLucroVendasLocacao rpt = new RelatorioLucroVendasLocacao();
            rpt.SetDatabaseLogon(usuario, senha);
            rpt.SetParameterValue(0, txtInicial.Text);
            rpt.SetParameterValue(1, txtFinal.Text);
            frmRelatorio rel = new frmRelatorio();
            rel.crystalReportViewer1.ReportSource = rpt;
            rel.ShowDialog();
            rel = null;
            rpt = null;
        }

        private void maskedTextBox4_KeyUp(object sender, KeyEventArgs e)
        {
            decimal numero;
            if (txtValorImovel.Text != null)
            {
                if (decimal.TryParse(maskedTextBox4.Text, out numero))
                {
                    //o codigo abaixo é para calcular a comissão !
                    //txtValorVendaImovel.Text = (Decimal.Parse(txtValorImovel.Text) * ((Decimal.Parse(maskedTextBox4.Text)) / 100)).ToString();
                    txtValorVendaImovel.Text = (Decimal.Parse(txtValorImovel.Text) + (Decimal.Parse(txtValorImovel.Text) * ((Decimal.Parse(maskedTextBox4.Text)) / 100))).ToString();
                }
                else
                    txtValorVendaImovel.Text = "";

            }
            else
                txtValorVendaImovel.Text = "";
        }

        private void txtPorcentagem2_KeyUp(object sender, KeyEventArgs e)
        {
            decimal numero;
            if (txtValor.Text != null)
            {
                string allowedchar = "0123456789";
                if (txtPorcentagem2.Text.All(allowedchar.Contains))
                {


                    if (decimal.TryParse(txtPorcentagem2.Text, out numero))
                    {
                        //decimal v = (Decimal.Parse(txtPorcentagem.Text));
                        //txtComissao.Text = (Decimal.Parse(txtValor.Text) * ((Decimal.Parse(txtPorcentagem.Text)) / 100)).ToString();
                        txtComissao.Text = (Decimal.Parse((txtValor.Text)) * ((Decimal.Parse(txtPorcentagem2.Text)) / 100)).ToString();
                        if (txtPorcentagem2.TextLength == 1)
                            txtComissao.Text = txtComissao.Text.Remove(txtComissao.TextLength - 2);
                        //else
                          //  txtComissao.Text = txtComissao.Text.Remove(txtComissao.TextLength - 1);


                    }
                    else
                        txtComissao.Text = "";
                }
                else
                {
                    MessageBox.Show("Digite apenas numeros !");
                    txtPorcentagem2.Text = "";
                }
                    
            }
            else
                txtComissao.Text = "";
        }
        //txtComissaoTeste.Text = (Decimal.Parse(txtValorTeste.Text) * (Decimal.Parse(txtPorcentagemTeste.Text) / 100)).ToString();
        //usar para buscar as cidades pelo nome do estado
        //EnderecoBusiness endbus = new EnderecoBusiness();

        //cbCidade.DataSource = endbus.listarCidades(cbEstado.SelectedValue.ToString());
        //cbCidade.ValueMember = "name";
        //cbCidade.DisplayMember = "name";
    }
}
