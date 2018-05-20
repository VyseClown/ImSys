using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class AgendaDominio
    {
        public void AdicionarAgendamento(visita vis)
        {
            try
            {
                using (ImobGentilEntities db = new ImobGentilEntities())
                {
                    db.visita.Add(vis);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
                //MessageBox.Show(e.Message);
            }
        }
        public void AdicionarInteresse(interesse inte)
        {
            try
            {
                using (ImobGentilEntities db = new ImobGentilEntities())
                {
                    db.interesse.Add(inte);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
                //MessageBox.Show(e.Message);
            }
        }

        //public List<PessoaCorretorModel> listarCorretoresComHorarioLivre(string horario, DateTime data)
        //{
        //    List<PessoaCorretorModel> lista = new List<PessoaCorretorModel>();
        //    string nomecorretorvazio = "";
        //    using (ImobGentilEntities db = new ImobGentilEntities())
        //    {
        //        lista = (from cor in db.corretor
        //                 from vis in db.visita
        //                 where (cor.pessoa.nome.Contains(nomecorretorvazio) && vis.data == data && vis.hora != horario)

        //                 select new PessoaCorretorModel()
        //                 {
        //                     id = cor.id,
        //                     Nome = cor.pessoa.nome,
        //                     VendasRealizadas = cor.vendasrealizadas.Value,


        //                 }).ToList();
        //    }


        //    return lista;
        //}

        // sobre a função abaixo //depois tenho que pesquisar pela
        //categoria também


        //public List<PessoaCorretorModel> listarCorretoresComHorarioLivre(string horario, DateTime data, int idcatimovel)
        //{
        //    List<PessoaCorretorModel> lista = new List<PessoaCorretorModel>();
        //    string nomecorretorvazio = "";
        //    using (ImobGentilEntities db = new ImobGentilEntities())
        //    {
        //        lista = (from cor in db.corretor
        //                 from vis in db.visita
        //                 where (cor.pessoa.nome.Contains(nomecorretorvazio) || vis.data == data && vis.hora != horario)

        //                 select new PessoaCorretorModel()
        //                 {
        //                     id = cor.id,
        //                     Nome = cor.pessoa.nome,
        //                     VendasRealizadas = cor.vendasrealizadas.Value,


        //                 }).ToList();
        //    }


        //    return lista;
        //}
        public PessoaCorretorModel verificarSeTemCompromisso(string horario, DateTime data, int iddocorretor)
        {
            PessoaCorretorModel corre = new PessoaCorretorModel();

            using(ImobGentilEntities db = new ImobGentilEntities())
            {
                corre = (
                         from vis in db.visita
                         where vis.data == data && vis.hora == horario && vis.idcorretor == iddocorretor
                         join esp in db.corretor on iddocorretor equals esp.id
                         select new PessoaCorretorModel()
                         {
                             id = esp.id,
                             Nome = esp.pessoa.nome,
                             VendasRealizadas = esp.vendasrealizadas.Value,

                         }).FirstOrDefault();
            }
            return corre;
        }
        public bool verificarDisponibilidadeImovel(string horario, DateTime data, int iddoimovel)
        {
            imovel imo = new imovel();
            using(ImobGentilEntities db = new ImobGentilEntities())
            {
                imo = (from vis in db.visita
                       where vis.data == data && vis.hora == horario && vis.idimovel == iddoimovel
                       join i in db.imovel
                       on iddoimovel equals i.id
                       select i).FirstOrDefault();
            }
            if (imo == null)
                return true;
            else
                return false;
        }

        public bool verificarDisponibilidadeCliente(string horario, DateTime data, int iddocliente)
        {
            cliente imo = new cliente();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                imo = (from vis in db.visita
                       where vis.data == data && vis.hora == horario && vis.idcliente == iddocliente
                       join i in db.cliente
                       on iddocliente equals i.id
                       select i).FirstOrDefault();
            }
            if (imo == null)
                return true;
            else
                return false;
        }
        public List<PessoaCorretorModel> listarCorretoresComHorarioLivre(string horario, DateTime data, int idcatimovel)
        {
            List<PessoaCorretorModel> lista = new List<PessoaCorretorModel>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from esp in db.especializacao
                         where esp.idcategoria == idcatimovel
                         join cor in db.corretor on esp.idcorretor equals cor.id
                         from vis in db.visita// on data equals vis.data where (((vis.hora != horario)) || true) == true
                                              // where ((((vis.data == data) && (vis.hora != horario)) ||  true) == true)
                         //como a tabela esta vazia, não tem nada para vir do FROM que coincida com o que tem acima, fudeu
                         select new PessoaCorretorModel()
                         {
                             id = cor.id,
                             Nome = cor.pessoa.nome,
                             VendasRealizadas = cor.vendasrealizadas.Value,

                         }).ToList();
            }

            return lista;
        }
        public List<PessoaCorretorModel> listarCorretoresPelaCategoria(int idcatimovel)
        {
            List<PessoaCorretorModel> lista = new List<PessoaCorretorModel>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from esp in db.especializacao
                         where esp.idcategoria == idcatimovel
                         join cor in db.corretor on esp.idcorretor equals cor.id
                         
                         select new PessoaCorretorModel()
                         {
                             id = cor.id,
                             Nome = cor.pessoa.nome,
                             VendasRealizadas = cor.vendasrealizadas.Value,


                         }).ToList();
            }


            return lista;
        }

        //public visita selecionarVisita(int idvisita)
        //{

        //}
        public List<VisitaModel> listarTodasVisitas()
        {
            
            List<VisitaModel> lista = new List<VisitaModel>();
            using(ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from vis in db.visita
                         where vis.resultado == "Pendente"
                         select new VisitaModel() {
                             corretorcomissao = vis.corretorcomissao.Value,
                             data = vis.data.Value,
                             hora = vis.hora,
                             id = vis.id,
                             idcliente = vis.idcliente.Value,
                             idcorretor = vis.idcorretor.Value,
                             idimovel = vis.idimovel.Value,
                             resultado = vis.resultado,
                             status = vis.status,
                         }).ToList();
            }


            return lista;
        }
        public List<interesse> listarTodosInteresses()
        {

            List<interesse> lista = new List<interesse>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from inte in db.interesse
                         select inte).ToList();
            }


            return lista;
        }
        public List<InteresseModel> listarTodosInteressesSemVisita()
        {

            List<InteresseModel> lista = new List<InteresseModel>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from inte in db.interesse
                         where inte.status == "Sem visita"
                         select new InteresseModel
                         {
                             id = inte.id,
                             nome = inte.pessoa.nome,
                             telefone = inte.pessoa.telefone,
                             email = inte.pessoa.email,
                             cpf = inte.pessoa.cpf,
                             data = inte.data.Value,
                             status = inte.status,
                             idimovel = inte.idimovel.Value,
                             

                         }).ToList();
            }


            return lista;
        }
        public visita selecionarVisitaComID(int id)
        {
            visita vis = new visita();
            using(ImobGentilEntities db = new ImobGentilEntities())
            {
                vis = (from vi in db.visita
                       where vi.id == id
                       select vi).FirstOrDefault();
            }
            return vis;
        }
        public void adicionarVenda(vendas ven)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                db.vendas.Add(ven);
                db.SaveChanges();
            }
        }
        public int adicionarAluguelRetornaID(locacoes aluguel)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                db.locacoes.Add(aluguel);
                db.SaveChanges();
                db.Entry(aluguel).GetDatabaseValues();
                return aluguel.id;
            }
        }
        public void adicionarPagamento(pagamentos pag)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                db.pagamentos.Add(pag);
                db.SaveChanges();
            }
        }
        public void modificarStatusVisita(visita vis)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(vis).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public void modificarStatusInteresse(interesse inte)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(inte).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public interesse selecionarInteresseComID(int id)
        {
            interesse inte = new interesse();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                inte = (from vi in db.interesse
                       where vi.id == id
                       select vi).FirstOrDefault();
            }
            return inte;
        }

        public vendas existeVenda(int idimovel)
        {
            vendas vend;
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                vend = (from ven in db.vendas
                 where ven.visita.idimovel == idimovel
                 select ven).FirstOrDefault();
            }
            return vend;
        }
        public locacoes existeAluguel(int idimovel)
        {
            locacoes loca;
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                loca = (from loc in db.locacoes
                        where loc.visita.idimovel == idimovel
                        select loc).FirstOrDefault();
            }
            return loca;
        }


    }
}
