using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Business
{
    public class ImovelBusiness
    {
        public List<categoria> listarCategorias(string categoria)
        {
            List<categoria> lista = new List<categoria>();

            ImovelDominio enddom = new ImovelDominio();
            lista = enddom.listarTodasCategorias(categoria);
            return lista;
        }
        public int pegarIDCategoria(string categoria)
        {
            ImovelDominio imodom = new ImovelDominio();
            int idcat = imodom.pegarIDCategoria(categoria);
            return idcat;
        }

        public List<ImovelEnderecoModel> listarimovelPorCategoriaeValor(int categoria)
        {
            List<ImovelEnderecoModel> lista = new List<ImovelEnderecoModel>();
            ImovelDominio imoveldom = new ImovelDominio();
            lista = imoveldom.listarImovelPorCategoria(categoria);
            return lista;
        }

        public List<imovel> listarImoveis(decimal valor)
        {
            List<imovel> lista = new List<imovel>();

            ImovelDominio enddom = new ImovelDominio();
            lista = enddom.listarTodosImoveis(valor);
            return lista;
        }
        public List<imovel> listarImoveisValor(int valor)
        {
            List<imovel> lista = new List<imovel>();

            ImovelDominio enddom = new ImovelDominio();
            lista = enddom.ListarPorValor(valor);
            
            //continuar a mostragem, cadastrar os imoveis certinho e já deverá funcionar com algumas horas de tentativa
            return lista;
        }
        public List<imovel> listarImoveisporCategoriasemValor(int cat)
        {
            List<imovel> lista = new List<imovel>();

            ImovelDominio enddom = new ImovelDominio();
            lista = enddom.listarImovelPorCategoriasemValor(cat);

            //continuar a mostragem, cadastrar os imoveis certinho e já deverá funcionar com algumas horas de tentativa
            return lista;
        }
        public List<imovel> listarPorValoreCategoria(int valor, int categoria)
        {
            List<imovel> lista = new List<imovel>();

            ImovelDominio imodom = new ImovelDominio();

            return lista = imodom.ListarPorValoreCategoria(valor, categoria);
        }
        public imovel SelecionarImovel(int id)
        {
            imovel imov;
            return imov = new ImovelDominio().SelecionarImovel(id);
        }
        public ImovelProprietarioModel retornarImovelComProprietario (int id)
        {
            ImovelDominio imodom = new ImovelDominio();

            return imodom.retornarImovelComProprietario(id);
        }
    }
}
