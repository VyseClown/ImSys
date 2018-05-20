using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ImovelDominio
    {
        public void adicionarImovel(imovel imo)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                db.imovel.Add(imo);
                db.SaveChanges();
            }
        }
        public void adicionarImagemAoImovel(imovel imo)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                db.Entry(imo).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public int pegarIDCategoria(string categoria)
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

        public void modificarImovel(imovel imo)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(imo).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    //throw;
                }

            }
        }

        public ImovelProprietarioModel retornarImovelComProprietario (int idimovel)
        {
            ImovelProprietarioModel imovelproprietario = new ImovelProprietarioModel();

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                imovelproprietario = (from imo in db.imovel
                                      where imo.id == idimovel

                                      join tabprop in db.cliente on imo.idproprietario equals tabprop.id
                                      //join pesprop in db.pessoa on tabcli.id equals pesprop.id

                                      //join tabcli in db.cliente on imo.idcliente equals tabcli.id



                                      //esquece a linha abaixo
                                      //join pescli in db.pessoa on tabclicli.id equals pescli.id

                                      join end in db.endereco on imo.idendereco equals end.id
                                      select new ImovelProprietarioModel()
                                      {
                                          areacon = imo.areacon,
                                          areater = imo.areater,
                                          bairro = end.bairro,
                                          categoria = imo.categoria.nome,
                                          CEP = end.cep,
                                          cidade = end.City.Name,
                                          logradouro = end.logradouro,
                                          //nomecliente = tabcli.pessoa.nome,
                                          nomeproprietario = tabprop.pessoa.nome,
                                          numero = end.numero.Value,
                                          valor = imo.valor.Value,
                                          valorvenda = imo.valorvendalocacao.Value,
                                          idimovel = imo.id,
                                          //idcliente = tabcli.pessoa.id,
                                          //CPFCliente = tabcli.pessoa.cpf,
                                          //TelefoneCliente = tabcli.pessoa.telefone,
                                          CPFProprietario = tabprop.pessoa.cpf,
                                          qtdquartos = imo.qtdquartos.Value,
                                          idcatimovel = imo.categoria.id,
                                          estado = imo.endereco.City.State.Name,
                                          finalidade = imo.finalidade,
                                          publicacao = imo.publicacaostatus,
                                

                            }).FirstOrDefault();
            }
            return imovelproprietario;
        }
        public void adicionarImagemGaleria(imagem img)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                db.imagem.Add(img);
                db.SaveChanges();
            }
        }

        public List<categoria> listarTodasCategorias(string categoria)
        {
            List<categoria> lista = new List<categoria>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from e in db.categoria
                         where e.nome.Contains(categoria)
                         orderby e.nome
                         select e).ToList();
            }
            return lista;
        }
        public List<categoria> listarTodasCategorias()
        {
            List<categoria> lista = new List<categoria>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from e in db.categoria
                         orderby e.nome
                         select e).ToList();
            }
            return lista;
        }
        public List<ImovelEnderecoModel> listarImovelPorCategoria(int categoria)
        {
            List<ImovelEnderecoModel> lista = new List<ImovelEnderecoModel>();

            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from i in db.imovel
                        where i.idcategoria == categoria
                        join end in db.endereco on i.idendereco equals end.id
                        join cat in db.categoria on categoria equals cat.id
                        join cid in db.City on end.cidade equals cid.Id
                        select new ImovelEnderecoModel()
                        {
                            cidade = cid.Name,
                            logradouro = end.logradouro,
                            bairro = end.bairro,
                            categoria = cat.nome,
                            valor = i.valorvendalocacao.Value
                            
                            
                        }).ToList();
            }


                return lista;
        }
        public List<imovel> listarTodosImoveis(decimal valor)
        {
            List<imovel> lista = new List<imovel>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from e in db.imovel
                         where e.valor.Equals(valor) && e.publicacaostatus=="Publicar"
                         orderby e.valor
                         select e).ToList();
            }
            return lista;
        }

        public List<imovel> listarUmImovelParaEnganar(int id)
        {
            List<imovel> lista = new List<imovel>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from e in db.imovel
                         where e.id == id
                         select e).ToList();
            }
            return lista;
        }

        public imovel SelecionarImovel(int id)
        {
            imovel retorno;
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                retorno = (from e in db.imovel
                      where e.id == id
                      select e).FirstOrDefault();
            }
            return retorno;
        }
        public imovel SelecionarUltimoImovel()
        {
            imovel retorno;
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                retorno = (from e in db.imovel
                           select e).ToList().Last();
            }
            return retorno;
        }

        public imovel SelecionarImovelcomEndereco(int idEndereco)
        {
            imovel retorno;
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                retorno = (from e in db.imovel
                           where e.idendereco == idEndereco
                           select e).FirstOrDefault();
            }
            return retorno;
        }
        public List<imovel> ListarPorValor(int valor2)
        {
            List<imovel> lista = new List<imovel>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                switch (valor2)
                {
                    case 0:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 0 && e.valorvendalocacao < 120000 && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 1:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 15000 && e.valorvendalocacao < 30000 && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 2:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 29999 && e.valorvendalocacao < 60000 && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 3:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 59999 && e.valorvendalocacao < 90000 && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;

                    case 4:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 89999 && e.valorvendalocacao < 120000 && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 5:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 120000 && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 6:
                        lista = (from e in db.imovel
                                 where e.finalidade == "Aluguel"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 7:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 0 && e.valorvendalocacao < 800 && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 8:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 799 && e.valorvendalocacao < 1600 && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 9:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 1599 && e.valorvendalocacao < 2400 && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 10:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 2399 && e.valorvendalocacao < 3000 && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 11:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 2999 && e.valorvendalocacao < 15001 && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 12:
                        lista = (from e in db.imovel
                                 where e.finalidade == "Venda"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    default:
                        break;
                }

            }
            return lista;
        }
        public List<imovel> listarImovelPorCategoriasemValor(int cat)
        {
            List<imovel> lista = new List<imovel>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = ((from i in db.imovel
                          where i.idcategoria == cat && i.publicacaostatus == "Publicar"
                          select i).ToList());
            }
            return lista;

        }
        public List<imovel> ListarPorValoreCategoria(int valor2, int categoria)
        {
            List<imovel> lista = new List<imovel>();
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                switch (valor2)
                {
                    case 0:
                        lista = (from e in db.imovel where e.publicacaostatus == "Publicar"
                                 join c in db.categoria on categoria equals c.id
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 1:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 15000 && e.valorvendalocacao < 30000 && e.idcategoria == categoria && e.publicacaostatus == "Publicar"

                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 2:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 29999 && e.valorvendalocacao < 60000 && e.idcategoria == categoria && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 3:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 59999 && e.valorvendalocacao < 90000 && e.idcategoria == categoria && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;

                    case 4:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 89999 && e.valorvendalocacao < 120000 && e.idcategoria == categoria && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 5:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 120000 && e.idcategoria == categoria && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 7:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 0 && e.valorvendalocacao < 800 && e.idcategoria == categoria && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 8:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 799 && e.valorvendalocacao < 1600 && e.idcategoria == categoria && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 9:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 1599 && e.valorvendalocacao < 2400 && e.idcategoria == categoria && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 10:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 2399 && e.valorvendalocacao < 3000 && e.idcategoria == categoria && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;
                    case 11:
                        lista = (from e in db.imovel
                                 where e.valorvendalocacao > 2999 && e.valorvendalocacao < 15001 && e.idcategoria == categoria && e.publicacaostatus == "Publicar"
                                 orderby e.valorvendalocacao
                                 select e).ToList();
                        break;


                    default:
                        break;
                }

            }
            return lista;
        }

        public void modificarStatusImovelPublicacao(imovel imo)
        {
            using (ImobGentilEntities db = new ImobGentilEntities())
            {
                try
                {
                    db.Entry(imo).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        
        
        public List<ImovelModel> listarImoveisAluguel()
        {
            List<ImovelModel> lista = new List<ImovelModel>();
            DateTime hoje = DateTime.Today;
            DateTime DoisMesesAtras = hoje.AddMonths(-2);
            using(ImobGentilEntities db = new ImobGentilEntities())
            {
                lista = (from i in db.imovel
                         join cli in db.cliente on i.idcliente equals cli.id
                         join vis in db.visita on i.id equals vis.idimovel
                         join loc in db.locacoes on vis.id equals loc.idvisita
                         from pag in db.pagamentos where loc.id == pag.idlocacoes && i.finalidade == "Aluguel" && pag.datap > DoisMesesAtras

                         select new ImovelModel()
                         {
                             id = i.id,
                             clienteNome = cli.pessoa.nome,
                             finalidade = i.finalidade,
                             dataultimopagamento = pag.datap.Value,
                             idLocacao = loc.id,
                             
                         }).ToList();
            }
            return lista;
        }


    }

        

    
}
