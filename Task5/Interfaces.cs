using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

interface IVisitable {
   void Accept(IVisitor vtor);
}

interface IVisitor {
   void Visit(Literal elem);
   void Visit(Add elem);
   void Visit(Mul elem);
   void Visit(Div elem);
   void Visit(Fct elem);
   void Visit(Max elem);
}