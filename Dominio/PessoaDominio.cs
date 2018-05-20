using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PessoaDominio
    {

        public permissoes logarNoSistema(string login, string senha)
        {
            
            permissoes per = new permissoes();

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                per = (from p in db.permissoes
                       join usu in db.usuario on p.idusuario equals usu.id
                       where usu.usuario1 == login && usu.senha == senha select p).FirstOrDefault();
                return per;
            }
            //terei que ver se o cara existe, caso existir, ver todas as permissões que ele tem, as que ele não tiver
            //retirarei as tabs que ele pode usar
            
        }

        public int selecionarUsu(string login, string senha)
        {
            int id;
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                id = (from usu in db.usuario
                      where usu.usuario1 == login && usu.senha == senha
                      select usu.id).FirstOrDefault();
                return id;
            }
        }

        public UsuarioModel selecionarUsuObj(int idpessoa)
        {
            UsuarioModel usu = new UsuarioModel();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                usu = (from u in db.usuario
                       join p in db.pessoa on u.idpessoa equals p.id
                       select new UsuarioModel()
                       {
                           id = u.id,
                           nome = p.nome,
                           usuario = u.usuario1,
                           senha = u.senha,
                       }

                       ).FirstOrDefault();
                return usu;
            }
        }
        public usuario selecionarObjUsuario(int idpessoa)
        {
            usuario usu = new usuario();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                usu = (from u in db.usuario
                       where u.idpessoa == idpessoa
                       select u).FirstOrDefault();
            }
            return usu;
        }
        public void modificarUsuario(usuario usu)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(usu).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                   //só para não dar erro                    
                }
                
            }
        }
        public void modificarPessoa(pessoa pes)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(pes).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                   // throw;
                }
                
            }
        }
        public void modificarEndereco(endereco end)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(end).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    //throw;
                }
                
            }
        }
        public void modificarCorretor(endereco end)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(end).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    //throw;
                }

            }
        }
        public List<UsuarioModel> listarUsuarios()
        {

            List<UsuarioModel> usu = new List<UsuarioModel>();

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                usu = (from u in db.usuario
                       join p in db.pessoa on u.idpessoa equals p.id
                       join per in db.permissoes on u.id equals per.idusuario
                       select new UsuarioModel()
                       {
                           id = u.id,
                           nome = p.nome,
                           usuario = u.usuario1,
                           gerenciarusuario = per.gerenciarusuario,
                           gerenciarvisita = per.gerenciarvisita,
                           gerenciarpagamentoaluguel = per.gerenciarpagamentoaluguel,
                           gerenciarpermissoes = per.gerenciarpermissoes,
                           gerenciarvendaaluguel = per.gerenciarvendaaluguel,
                           publicarimovel = per.publicarimovel,
                       }
                       
                       ).ToList();
                return usu;
            }
            //terei que ver se o cara existe, caso existir, ver todas as permissões que ele tem, as que ele não tiver
            //retirarei as tabs que ele pode usar

            //{//ao menos agora está funcionando
            //    list = (from e in db.especializacao
            //            where e.idcategoria == categoria
            //            join cor in db.corretor on e.idcorretor equals cor.id
            //            join p in db.pessoa on cor.idpessoa equals p.id
            //            select new PessoaCorretorModel()
            //            {
            //                id = cor.id,
            //                Nome = p.nome,
            //                VendasRealizadas = cor.vendasrealizadas.Value,
            //            }).ToList();
            //    return list;
            //}


        }
        public permissoes listarPermissoesdoUsuario(int iddousuario)
        {
            permissoes per = new permissoes();

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                per = (from p in db.permissoes
                       join usu in db.usuario on p.idusuario equals usu.id
                       where usu.id == iddousuario
                       select p).FirstOrDefault();
                return per;
            }
        }
        public string pegarNomeUsuario(int iddousuario)//parece funcionar, testar quando acordar
        {
            string nome = "";

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                nome = (from usu in db.usuario
                       join p in db.pessoa on usu.idpessoa equals p.id
                       where usu.id == iddousuario
                       select p.nome).FirstOrDefault();                
            }
            return nome;
        }
        public void adicionarRegistroPermissaoParaNovoUsuario(permissoes per)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                db.permissoes.Add(per);
                db.SaveChanges();
            }
        }
        public void modificarPermissao(permissoes per)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                db.Entry(per).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void AdicionarPessoa(pessoa pes)
        {
            try
            {
                using (ImobGentilEntities db = new ImobGentilEntities())
                {//adicionar pessoa e vir com a opção, se a mesma vai ser usuario, cliente ou corretor
                    db.pessoa.Add(pes);
                    //é necessario adicionar no banco, depois fazer um select ou arranjar uma forma de pegar o ultimo adicionado e adicionar a chave estrangeira no usuario
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
                //MessageBox.Show(e.Message);
            }
        }
        public int selecionarUltimaPessoaIDcomCPF(pessoa pes)
        {
            int id = 0;

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                id = (from p in db.pessoa where pes.cpf == p.cpf select p.id).FirstOrDefault();
                return id;
            }
            
        }

        public int selecionarUltimaPessoaID()
        {
            int id = 0;

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                id = (from p in db.pessoa select p.id).LastOrDefault();
                return id;
            }

        }


        public int selecionarPessoaIDcomCPF(string cpf)
        {
            int id = 0;

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                id = (from p in db.pessoa where cpf == p.cpf select p.id).FirstOrDefault();
                return id;
            }

        }
        public corretor selecionarCorretorcomCPF(string cpf)
        {
            corretor corret = new corretor(); ;

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                corret = (from p in db.pessoa
                      join c in db.corretor on p.id equals c.idpessoa
                      where cpf == p.cpf select c).FirstOrDefault();
                return corret;
            }

        }

        public pessoa selecionarPessoacomCPF(string cpf)
        {
            pessoa pes;

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                pes = (from p in db.pessoa where cpf == p.cpf select p).FirstOrDefault();
                return pes;
            }

        }

        public int selecionarPessoaID(pessoa pes)
        {
            int id = 0;

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                id = (from p in db.pessoa where pes.id == p.id select p.id).FirstOrDefault();
                return id;
            }

        }

        public List<corretor> listarCorretores(pessoa pes)
        {
            
            List<corretor> list = new List<corretor>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                list = (from p in db.corretor where pes.id == p.id select p).ToList();
                return list;
            }

        }
        public bool verificarSeJaExisteEspecializacao(int idcat, int idcor)
        {
            especializacao esp = new especializacao();
            using(ImobGentilEntities db = new ImobGentilEntities())
            {
                esp = (from e in db.especializacao
                       where e.idcategoria == idcat && e.idcorretor == idcor
                       select e).FirstOrDefault();
            }
            if (esp == null)
                return true;
            else
                return false;
        }

        public class categoriasdocorretorModel
        {
            public int id { get; set; }
            public string nome { get; set; }
        }

        public List<categoriasdocorretorModel> listarCategoriasDoCorretor(int idcorretor)
        {
            List<categoriasdocorretorModel> categorias = new List<categoriasdocorretorModel>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                categorias = (from e in db.especializacao
                              join c in db.categoria on e.idcategoria equals c.id
                              where e.idcorretor == idcorretor
                              select new categoriasdocorretorModel()
                              {
                                  id = c.id,
                                  nome = c.nome,
                              }
                              ).ToList();
            }
            return categorias;
        }
        public List<PessoaCorretorModel> listarCorretoresPorCategoria(int categoria)
        {

            List<PessoaCorretorModel> list = new List<PessoaCorretorModel>();

            using (ImobGentilEntities db = new ImobGentilEntities())
            {//ao menos agora está funcionando
                list = (from e in db.especializacao where e.idcategoria == categoria
                        join cor in db.corretor on e.idcorretor equals cor.id
                        join p in db.pessoa on cor.idpessoa equals p.id
                        select new PessoaCorretorModel() {
                            id = cor.id,
                            Nome = p.nome,
                            VendasRealizadas = cor.vendasrealizadas.Value,
                            }).ToList();
                return list;
            }
            //nesse metodo, tenho que pesquisar qual corretor no banco está inserido em tal categoria e só então trazer ele

        }
        public CorretorModel selecionarCorretor(int id)
        {
            CorretorModel corretor = new CorretorModel();

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                corretor = (from cor in db.corretor
                            where cor.id == id
                            join pes in db.pessoa on cor.idpessoa equals pes.id
                            join end in db.endereco on pes.idendereco equals end.id
                            select new CorretorModel()
                            {
                                Nome = pes.nome,
                                CPF = pes.cpf,
                                celular = pes.celular,
                                cidade = end.City.Name,
                                estado = end.City.State.Name,
                                logradouro = end.logradouro,
                                numero = end.numero.Value,
                                telefone = pes.telefone,
                                bairro = end.bairro,
                                CEP = end.cep,
                                email = pes.email,
                                

                            }).First();
            }
            return corretor;
        }
        //public List<object> listarCorretoresPorCategoria(pessoa pes, int categoria)
        //{

        //    List<object> list = new List<object>();

        //    using (ImobGentilEntities db = new ImobGentilEntities())
        //    {//descobrir como fazer essa merda hoje
        //        list = (from e in db.especializacao
        //                join cor in db.corretor on e.idcorretor equals cor.id
        //                join pessoa in db.pessoa on cor.idpessoa equals pessoa.id
        //                join cat in db.categoria on e.idcategoria equals cat.id
        //                select new { pessoa.nome, pessoa.telefone }).ToList();
        //        //list = (from p in db.corretor where pes.id == p.id select p).ToList();
        //        return list;
        //    }

        //}

        public corretor selecionarCorretor(pessoa pes)
        {
            corretor cor;
            
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                cor = (from p in db.corretor where pes.id == p.id select p).FirstOrDefault();
                return cor;
            }

        }
        public cliente selecionarCliente(pessoa pes)
        {
            cliente cli;

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                cli = (from c in db.cliente where pes.id == c.idpessoa select c).FirstOrDefault();
                return cli;
            }

        }

        public cliente selecionarClienteComIDPessoa(int idpessoa)
        {
            cliente cli;

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                cli = (from c in db.cliente
                       join p in db.pessoa on c.idpessoa equals p.id
                       where p.id == idpessoa
                       select c).FirstOrDefault();
                return cli;
            }

        }
        public pessoa selecionarPessoaRetornarCPF(int id)
        {
            pessoa cli;

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                cli = (from c in db.pessoa where id == c.id select c).FirstOrDefault();
                return cli;
            }

        }
        public pessoa selecionarPessoaComIDCliente(int idcliente)
        {
            pessoa cli;
            
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                cli = (from c in db.cliente where idcliente == c.id
                       join p in db.pessoa on c.idpessoa equals p.id
                       select p).FirstOrDefault();
                return cli;
            }

        }



        public void AdicionarUsuario(usuario usu)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.usuario.Add(usu);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void AdicionarCorretor(corretor cor)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.corretor.Add(cor);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }
        public void AdicionarEspecializacao(especializacao esp)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.especializacao.Add(esp);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public int SelecionarUltimoCorretor(int idpessoa)
        {
            int id = 0;

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                id = (from p in db.corretor where idpessoa == p.idpessoa select p.id).FirstOrDefault();
                return id;
            }
        }

        public void AdicionarCliente(cliente cli)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.cliente.Add(cli);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void AdicionarEnderecoIDUsuario(pessoa pes)//funciona para adicionar o ID em todos
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(pes).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public int PegarIDCategoria(string categoria)
        {
            int id = 0;
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                id = (from e in db.categoria
                      where e.nome.Contains(categoria)
                      select e.id).FirstOrDefault();
            }
            return id;
        }
        public void AtualizarEnderecoIDdoCliente(int idendereco)
        {

        }

        public void alterarUsu(pessoa pes, usuario usu, endereco end)//funciona para adicionar o ID em todos
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(pes).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(usu).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(end).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public void alterarCli(pessoa pes, cliente cli, endereco end)//funciona para adicionar o ID em todos
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(pes).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(cli).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(end).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void alterarCorretor(pessoa pes, corretor cor, endereco end)//funciona para adicionar o ID em todos
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(pes).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(cor).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(end).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public void alterarCorretorVendasAluguel(corretor cor)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                db.Entry(cor).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
