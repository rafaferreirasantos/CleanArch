using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Abstractions
{
  internal interface IUnitofWork
  {
    IMemberRepository MemberRepository { get; }
    Task CommitAsync();
  }
}
