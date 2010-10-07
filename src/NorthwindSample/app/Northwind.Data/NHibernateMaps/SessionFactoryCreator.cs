using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using SharpArch.Data.NHibernate;

namespace Northwind.Data.NHibernateMaps
{
    public class SessionFactoryCreator
    {
        public static ISessionFactory Create(Configuration cfg)
        {
            return Fluently.Configure(cfg)

                .Mappings(m =>
                              {
                                  var assembly = typeof (SessionFactoryCreator).Assembly;

                                  m.HbmMappings.AddFromAssembly(assembly);
                                  m.FluentMappings.AddFromAssembly(assembly)
                                      .Conventions.AddAssembly(assembly);


                                  m.AutoMappings.Add(new AutoPersistenceModelGenerator().Generate());
                              })


                .BuildSessionFactory();

        }
    }
}
