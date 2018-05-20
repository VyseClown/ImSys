using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EnderecoDominio
    {
        public void AdicionarEndereco(endereco end)
        {
            try
            {
                using (ImobGentilEntities db = new ImobGentilEntities())
                {//adicionar pessoa e vir com a opção, se a mesma vai ser usuario, cliente ou corretor
                    db.endereco.Add(end);
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
        public int selecionarUltimoEnderecoID(endereco end)
        {
            int id = 0;

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                id = (from e in db.endereco where e.logradouro.Contains(end.logradouro) orderby e.id descending select e.id).First();
                return id;
            }

        }

        public endereco selecionarEndereco(string logradouro)
        {
            endereco end = new endereco();

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                end = (from e in db.endereco where e.logradouro.Contains(logradouro) orderby e.id descending select e).First();
                return end;
            }
            
            
        }

        public endereco selecionarEnderecoComRuaeNumero(string logradouro, int numero)
        {
            endereco end = new endereco();

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                end = (from e in db.endereco where e.logradouro.Contains(logradouro) && e.numero == numero orderby e.id descending select e).First();
                return end;
            }


        }


        public List<State> listarTodosEstados(string estado)
        {
            List<State> lista = new List<State>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from e in db.State
                         where e.Name.Contains(estado)
                         orderby e.Name
                         select e).ToList();
            }
            return lista;
        }

        public List<State> listarTodosEstados()
        {
            List<State> lista = new List<State>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from e in db.State
                         orderby e.Name
                         select e).ToList();
            }
            return lista;
        }

        public int pegarIDEstado(string estado)
        {
            int id = 0;
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                id = (from e in db.State
                         where e.Name.Contains(estado)
                         select e.Id).FirstOrDefault();
            }
            return id;
        }
        public int pegarIDEstadoInt(int cid)
        {
            int id = 0;
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                id = (from e in db.State
                      join c in db.City on e.Id equals c.IdState
                      where c.Id == cid
                      select e.Id).FirstOrDefault();
            }
            return id;
        }
        public string pegarNomeEstadoInt(int cid)
        {
            string nome = "";
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                nome = (from e in db.State
                      join c in db.City on e.Id equals c.IdState
                      where c.Id == cid
                      select e.Name).FirstOrDefault();
            }
            return nome;
        }
        public int pegarIDCidade(string cidade)
        {
            int id = 0;
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                id = (from e in db.City
                      where e.Name.Contains(cidade)
                      select e.Id).FirstOrDefault();
            }
            return id;
        }

        public string pegarNomeCidade(int cidade)
        {
            string nome = "";
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                //nome = (from c in db.City
                //      where c.Id == cidade
                //      select c.Name).FirstOrDefault();
                nome = db.City.Find(cidade).Name;
            }
            return nome;
            
        }



        //buscar o ID do estado para usar na listagem de cidades
        public List<City> listarTodasCidades(int estado)
        {
            List<City> lista = new List<City>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from e in db.City
                         where e.IdState == estado
                         orderby e.Name
                         select e).ToList();
            }
            return lista;
        }

        public List<City> listarCidadesTodas(string estado)
        {
            List<City> lista = new List<City>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from e in db.City
                         where e.State.Name == estado
                         orderby e.Name
                         select e).ToList();
            }
            return lista;
        }
        public endereco selecionarEnderecoPorID(int id)
        {
            endereco end = new endereco();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                end = (from e in db.endereco
                       where e.id == id
                       select e).First();
            }
            return end;
        }
        public City selecionarCidade(int id)
        {
            City cidade = new City();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                cidade = (from c in db.City
                          where c.Id == id
                          select c).First();
            }
            return cidade;
        }
        public State selecionarEstadoComIDdaCidade(int id)
        {
            State estado = new State();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                estado = (from c in db.City
                          join s in db.State on c.IdState equals s.Id
                          where c.Id == id
                          select s).First();
            }
            return estado;
        }
        public endereco verificarSeEnderecoExiste(int id)
        {
            endereco retorno = new endereco();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                retorno = (from e in db.endereco
                           join p in db.pessoa on e.id equals p.idendereco
                           where p.id == id
                           select e).FirstOrDefault();
            }
            return retorno;
        }

        public endereco selecionarEnderecoComIDPessoa(int idpessoa)
        {
            endereco end = new endereco();
            using(ImobGentilEntities db = new ImobGentilEntities())
            {
                end = (from p in db.pessoa
                       join e in db.endereco on p.idendereco equals e.id
                       where p.id == idpessoa
                       select e).FirstOrDefault();
            }
            return end;
        }

        public List<City> selecionarCidadeEnganar(int id)
        {
            List<City> cidade = new List<City>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                cidade = (from c in db.City
                          where c.Id == id
                          select c).ToList();
            }
            return cidade;
        }
        public List<State> selecionarEstadoEnganar(int id)
        {
            List<State> estado = new List<State>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                estado = (from c in db.City
                          join s in db.State on c.IdState equals s.Id
                          where c.Id == id
                          select s).ToList();
            }
            return estado;
        }
        //list = (from e in db.especializacao where e.idcategoria == categoria
        //                   join cor in db.corretor on e.idcorretor equals cor.id
        //                   join pessoa in db.pessoa on cor.idpessoa equals pessoa.id
        //                   //join cat in db.categoria on e.idcategoria equals cat.id
        //                   select pessoa).ToList();
    }
}
