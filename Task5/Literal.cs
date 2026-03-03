using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;


class Literal : IVisitable {
   public readonly int Value;
   public Literal(int Value) {
      this.Value = Value;
   }
   public void Accept(IVisitor vtor) => vtor.Visit(this);
}