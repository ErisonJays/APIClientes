﻿using APIClientes.Modelos;
using APIClientes.Modelos.Dto;
using AutoMapper;

namespace APIClientes
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {

            var mappingConfig = new MapperConfiguration(config => {

                config.CreateMap<ClienteDto, Cliente>();
                config.CreateMap<Cliente, ClienteDto>();
            
            });

            return mappingConfig;
      
        }
    }
}
