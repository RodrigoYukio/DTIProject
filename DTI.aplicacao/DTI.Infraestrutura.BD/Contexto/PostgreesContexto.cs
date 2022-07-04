using DTI.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Runtime.Session;

namespace DTI.Infraestrutura.BD.Contexto
{
    public class PostgreesContexto : DTIContexto
    {
        public PostgreesContexto(DbContextOptions<DTIContexto> options, ITnfSession session) : base(options, session)
        {
        }
    }
}
