﻿using System;
using System.Linq;
using WpfApplication2.Model;

namespace  WpfApplication2.DAL
{
    public class UnitOfWork : IDisposable
    {
        private TiendaContext context = new TiendaContext();
        private bool disposed = false;

        private RepositorioPedido repositorioPedido;
        private RepositorioCliente repositorioCliente;

        public RepositorioCliente RepositorioCliente
        {
            get
            {
                if (this.repositorioCliente== null)
                {
                    this.repositorioCliente =
                        new RepositorioCliente(context);
                }

                return repositorioCliente;
            }
        }
        public RepositorioPedido RepositorioPedido
        {
            get
            {
                if (this.repositorioPedido == null)
                {
                    this.repositorioPedido =
                        new RepositorioPedido(context);
                }

                return repositorioPedido;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}