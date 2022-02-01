using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IMove
    {
        void Move(bool isInupt, float direction, float vertical);
    }
}
