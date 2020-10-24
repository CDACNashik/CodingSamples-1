.method public hidebysig static void  Main() cil managed
{
  .entrypoint
  // Code size       26 (0x1a)
  .maxstack  1
  .locals init (float64 V_0,
           object V_1,
           float64 V_2)
  IL_0000:  nop
  IL_0001:  ldc.r8     9.75
  IL_000a:  stloc.0
  IL_000b:  ldloc.0
  IL_000c:  box        [mscorlib]System.Double
  IL_0011:  stloc.1
  IL_0012:  ldloc.1
  IL_0013:  unbox.any  [mscorlib]System.Double
  IL_0018:  stloc.2
  IL_0019:  ret
} // end of method Program::Main
