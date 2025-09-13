// IL code: EntryTrace.Console
.class private auto ansi '<Module>'
{
} // end of class <Module>

.class private auto ansi beforefieldinit Program
	extends [System.Runtime]System.Object
{
	.custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = (
		01 00 00 00
	)
	// Methods
	.method private hidebysig static 
		void '<Main>$' (
			string[] args
		) cil managed 
	{
		// Method begins at RVA 0x2050
		// Header size: 1
		// Code size: 12 (0xc)
		.maxstack 8
		.entrypoint

		IL_0000: ldstr "Hello, World!"
		IL_0005: call void [System.Console]System.Console::WriteLine(string)
		IL_000a: nop
		IL_000b: ret
	} // end of method Program::'<Main>$'

	.method public hidebysig specialname rtspecialname 
		instance void .ctor () cil managed 
	{
		// Method begins at RVA 0x205d
		// Header size: 1
		// Code size: 8 (0x8)
		.maxstack 8

		IL_0000: ldarg.0
		IL_0001: call instance void [System.Runtime]System.Object::.ctor()
		IL_0006: nop
		IL_0007: ret
	} // end of method Program::.ctor

} // end of class Program

