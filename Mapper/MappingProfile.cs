using AutoMapper;
using tl2_tp5_2022_nico89h.Models;
using tl2_tp5_2022_nico89h.ViewModels;

namespace tl2_tp5_2022_nico89h.Mapper
{
    public class MappingProfile:Profile
    {
        //inicio de el mapper, se usara para realizar la conversion de mapper

        public MappingProfile()
        {
            CreateMap<Cadetes,CadetesView>().ReverseMap();
            CreateMap<Pedidos,PedidosView>().ReverseMap();
        }

    }
}
