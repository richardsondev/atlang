
//  .NET IL Disassembler.  Version 9.0.0


// ----- DOS Header:
// Magic:                      0x5a4d
// Bytes on last page:         0x0090
// Pages in file:              0x0003
// Relocations:                0x0000
// Size of header (paragraphs):0x0004
// Min extra paragraphs:       0x0000
// Max extra paragraphs:       0xffff
// Initial (relative) SS:      0x0000
// Initial SP:                 0x00b8
// Checksum:                   0x0000
// Initial IP:                 0x0000
// Initial (relative) CS:      0x0000
// File addr. of reloc table:  0x0040
// Overlay number:             0x0000
// OEM identifier:             0x0000
// OEM info:                   0x0000
// File addr. of COFF header:  0x0080
// ----- COFF/PE Headers:
// Signature:                  0x00004550
// ----- COFF Header:
// Machine:                    0x014c
// Number of sections:         0x0002
// Time-date stamp:            0x67bda610
// Ptr to symbol table:        0x00000000
// Number of symbols:          0x00000000
// Size of optional header:    0x00e0
// Characteristics:            0x0002
// ----- PE Optional Header (32 bit):
// Magic:                          0x010b
// Major linker version:           0x30
// Minor linker version:           0x00
// Size of code:                   0x00000600
// Size of init.data:              0x00000200
// Size of uninit.data:            0x00000000
// Addr. of entry point:           0x0000254e
// Base of code:                   0x00002000
// Base of data:                   0x00004000
// Image base:                     0x00400000
// Section alignment:              0x00002000
// File alignment:                 0x00000200
// Major OS version:               0x0004
// Minor OS version:               0x0000
// Major image version:            0x0000
// Minor image version:            0x0000
// Major subsystem version:        0x0004
// Minor subsystem version:        0x0000
// Size of image:                  0x00006000
// Size of headers:                0x00000200
// Checksum:                       0x00000000
// Subsystem:                      0x0003
// DLL characteristics:            0x8540
// Size of stack reserve:          0x00100000
// Size of stack commit:           0x00001000
// Size of heap reserve:           0x00100000
// Size of heap commit:            0x00001000
// Loader flags:                   0x00000000
// Directories:                    0x00000010
// 0x00000000 [0x00000000] address [size] of Export Directory:          
// 0x000024fc [0x0000004f] address [size] of Import Directory:          
// 0x00000000 [0x00000000] address [size] of Resource Directory:        
// 0x00000000 [0x00000000] address [size] of Exception Directory:       
// 0x00000000 [0x00000000] address [size] of Security Directory:        
// 0x00004000 [0x0000000c] address [size] of Base Relocation Table:     
// 0x00000000 [0x00000000] address [size] of Debug Directory:           
// 0x00000000 [0x00000000] address [size] of Architecture Specific:     
// 0x00000000 [0x00000000] address [size] of Global Pointer:            
// 0x00000000 [0x00000000] address [size] of TLS Directory:             
// 0x00000000 [0x00000000] address [size] of Load Config Directory:     
// 0x00000000 [0x00000000] address [size] of Bound Import Directory:    
// 0x00002000 [0x00000008] address [size] of Import Address Table:      
// 0x00000000 [0x00000000] address [size] of Delay Load IAT:            
// 0x00002008 [0x00000048] address [size] of CLR Header:                


// Image sections:
//              .text
//              0x00000554 Virtual Size
//              0x00002000 Virtual Address
//              0x00000600 Size of Raw Data
//              0x00000200 Pointer to Raw Data
//              0x00000000 Pointer to Relocations
//              0x00000000 Pointer to Linenumbers
//                  0x0000 Number of Relocations
//                  0x0000 Number of Linenumbers
//              0x60000020 Characteristics
//                         CNT_CODE
//                         MEM_EXECUTE
//                         MEM_READ

//              .reloc
//              0x0000000c Virtual Size
//              0x00004000 Virtual Address
//              0x00000200 Size of Raw Data
//              0x00000800 Pointer to Raw Data
//              0x00000000 Pointer to Relocations
//              0x00000000 Pointer to Linenumbers
//                  0x0000 Number of Relocations
//                  0x0000 Number of Linenumbers
//              0x42000040 Characteristics
//                         CNT_INITIALIZED_DATA
//                         MEM_DISCARDABLE
//                         MEM_READ

// Base Relocation Table
//              0x00002000 Page RVA
//              0x0000000c Block Size
//              0x00000002 Number of Entries
//              Entry 1: Type 0x3 Offset 0x00000550
//              Entry 2: Type 0x0 Offset 0x00000000

// Import Address Table
//     DLL : mscoree.dll
//              0x00002000 Import Address Table
//              0x0000253e Import Name Table
//              0          Time Date Stamp
//              0          Index of First Forwarder Reference
//
//              0x0000  _CorExeMain

// Delay Load Import Address Table
// No data.

// Entry point code:
//FF 25 00 20 40 00 


// ----- CLR Header:
// Header size:                        0x00000048
// Major runtime version:              0x0002
// Minor runtime version:              0x0005
// 0x0000213c [0x00000340] address [size] of Metadata Directory:        
// Flags:                              0x00000001
// Entry point token:                  0x06000001
// 0x00000000 [0x00000000] address [size] of Resources Directory:       
// 0x0000247c [0x00000080] address [size] of Strong Name Signature:     
// 0x00000000 [0x00000000] address [size] of CodeManager Table:         
// 0x00000000 [0x00000000] address [size] of VTableFixups Directory:    
// 0x00000000 [0x00000000] address [size] of Export Address Table:      
// 0x00000000 [0x00000000] address [size] of Precompile Header:         

// Metadata Header
//    Storage Signature:
//              0x424a5342 Signature
//                  0x0001 Major Version
//                  0x0001 Minor Version
//              0x00000000 Extra Data Offset
//              0x0000000c Version String Length
//              'v4.0.30319' Version String
//    Storage Header:
//                    0x00 Flags
//                  0x0005 Number of Streams
//    Stream 1:
//              0x0000006c Offset
//              0x000000fc Size
//              '#~' Name
//    Stream 2:
//              0x00000168 Offset
//              0x000000cc Size
//              '#Strings' Name
//    Stream 3:
//              0x00000234 Offset
//              0x00000024 Size
//              '#US' Name
//    Stream 4:
//              0x00000258 Offset
//              0x00000010 Size
//              '#GUID' Name
//    Stream 5:
//              0x00000268 Offset
//              0x000000d8 Size
//              '#Blob' Name

//    Metadata Stream Header:
//              0x00000000 Reserved
//                    0x02 Major
//                    0x00 Minor
//                    0x00 Heaps
//                    0x01 Rid
//      0x0000000908020447 MaskValid
//      0x000016003301fa00 Sorted

// Code Manager Table:
//  default


// Export Address Table Jumps:
// No data.

// File size            : 2560
// PE header size       : 512 (456 used)    (20.00%)
// PE additional info   : 171               ( 6.68%)
// Num.of PE sections   : 2
// CLR header size     : 72                 ( 2.81%)
// CLR meta-data size  : 832                (32.50%)
// CLR additional info : 128                ( 5.00%)
// CLR method headers  : 13                 ( 0.51%)
// Managed code         : 220               ( 8.59%)
// Data                 : 512               (20.00%)
// Unaccounted          : 100               ( 3.91%)

// Num.of PE sections   : 2
//   .text    - 1536
//   .reloc   - 512

// CLR meta-data size  : 832
//   Module        -    1 (10 bytes)
//   TypeDef       -    2 (28 bytes)      0 interfaces, 0 explicit layout
//   TypeRef       -    6 (36 bytes)
//   MethodDef     -    2 (28 bytes)      0 abstract, 0 native, 2 bodies
//   MemberRef     -    7 (42 bytes)
//   StandAloneSig -    1 (2 bytes)
//   TypeSpec      -    1 (2 bytes)
//   Assembly      -    1 (22 bytes)
//   AssemblyRef   -    1 (20 bytes)
//   Strings       -   201 bytes
//   Blobs         -   216 bytes
//   UserStrings   -    36 bytes
//   Guids         -    16 bytes
//   Uncategorized -   173 bytes

// CLR additional info : 128

// CLR method headers : 13
//   Num.of method bodies  - 2
//   Num.of fat headers    - 1
//   Num.of tiny headers   - 1

// Managed code : 220
//   Ave method size - 110
// Classes defined in this module:
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// Class AtLangProgram                  (public) (auto) (ansi) 
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

// ================================= M E T A I N F O ================================================

// ===========================================================
// Metadata section: 0x424a5342, version: 1.1, extra: 0, version len: 12, version: v4.0.30319
//            flags: 0x00, streams: 5
// Stream 0: name: #~, size 252
// Stream 1: name: #Strings, size 204
// Stream 2: name: #US, size 36
// Stream 3: name: #GUID, size 16
// Stream 4: name: #Blob, size 216
// Metadata header: 2.0, heaps: 0x00, rid: 0x01, valid: 0x0000000908020447, sorted: 0x000016003301fa00
// 
// Strings: 201(0xc9), Blobs: 216(0xd8), Guids: 16(0x10), User strings: 36(0x24)
// =================================================
//  0(0): Module               cRecs:    1(0x1), cbRec: 10(0xa), cbTable:    10(0xa)
//   col  0:  Generation   oCol: 0, cbCol:2, USHORT 
//   col  1:  Name         oCol: 2, cbCol:2, string 
//   col  2:  Mvid         oCol: 4, cbCol:2, GUID   
//   col  3:  EncId        oCol: 6, cbCol:2, GUID   
//   col  4:  EncBaseId    oCol: 8, cbCol:2, GUID   
// -------------------------------------------------
//    1 == 0:0000, 1:string#4f, 2:guid#1, 3:guid#0, 4:guid#0
// =================================================
//  1(0x1): TypeRef              cRecs:    6(0x6), cbRec:  6(0x6), cbTable:    36(0x24)
//   col  0:  ResolutionScope oCol: 0, cbCol:2, ResolutionScope
//   col  1:  Name         oCol: 2, cbCol:2, string 
//   col  2:  Namespace    oCol: 4, cbCol:2, string 
// -------------------------------------------------
//    1 == 0:ResolutionScope[23000001], 1:string#1, 2:string#34
//    2 == 0:ResolutionScope[23000001], 1:string#e, 2:string#86
//    3 == 0:ResolutionScope[23000001], 1:string#5a, 2:string#86
//    4 == 0:ResolutionScope[23000001], 1:string#96, 2:string#86
//    5 == 0:ResolutionScope[23000001], 1:string#61, 2:string#86
//    6 == 0:ResolutionScope[23000001], 1:string#be, 2:string#86
// =================================================
//  2(0x2): TypeDef              cRecs:    2(0x2), cbRec: 14(0xe), cbTable:    28(0x1c)
//   col  0:  Flags        oCol: 0, cbCol:4, ULONG  
//   col  1:  Name         oCol: 4, cbCol:2, string 
//   col  2:  Namespace    oCol: 6, cbCol:2, string 
//   col  3:  Extends      oCol: 8, cbCol:2, TypeDefOrRef
//   col  4:  FieldList    oCol: a, cbCol:2, Field  
//   col  5:  MethodList   oCol: c, cbCol:2, Method 
// -------------------------------------------------
//    1 == 0:00000000, 1:string#14, 2:string#0, 3:TypeDefOrRef[02000000], 4:Field[4000001], 5:Method[6000001]
//    2 == 0:00000001, 1:string#66, 2:string#0, 3:TypeDefOrRef[01000006], 4:Field[4000001], 5:Method[6000001]
// =================================================
//  3(0x3): FieldPtr             cRecs:    0(0), cbRec:  2(0x2), cbTable:     0(0)
//   col  0:  Field        oCol: 0, cbCol:2, Field  
// =================================================
//  4(0x4): Field                cRecs:    0(0), cbRec:  6(0x6), cbTable:     0(0)
//   col  0:  Flags        oCol: 0, cbCol:2, USHORT 
//   col  1:  Name         oCol: 2, cbCol:2, string 
//   col  2:  Signature    oCol: 4, cbCol:2, blob   
// =================================================
//  5(0x5): MethodPtr            cRecs:    0(0), cbRec:  2(0x2), cbTable:     0(0)
//   col  0:  Method       oCol: 0, cbCol:2, Method 
// =================================================
//  6(0x6): Method               cRecs:    2(0x2), cbRec: 14(0xe), cbTable:    28(0x1c)
//   col  0:  RVA          oCol: 0, cbCol:4, ULONG  
//   col  1:  ImplFlags    oCol: 4, cbCol:2, USHORT 
//   col  2:  Flags        oCol: 6, cbCol:2, USHORT 
//   col  3:  Name         oCol: 8, cbCol:2, string 
//   col  4:  Signature    oCol: a, cbCol:2, blob   
//   col  5:  ParamList    oCol: c, cbCol:2, Param  
// -------------------------------------------------
//    1 == 0:00002050, 1:0000, 2:0096, 3:string#91, 4:blob#d3, 5:Param[8000001]
//    2 == 0:00002131, 1:0000, 2:1806, 3:string#b1, 4:blob#aa, 5:Param[8000001]
// =================================================
//  7(0x7): ParamPtr             cRecs:    0(0), cbRec:  2(0x2), cbTable:     0(0)
//   col  0:  Param        oCol: 0, cbCol:2, Param  
// =================================================
//  8(0x8): Param                cRecs:    0(0), cbRec:  6(0x6), cbTable:     0(0)
//   col  0:  Flags        oCol: 0, cbCol:2, USHORT 
//   col  1:  Sequence     oCol: 2, cbCol:2, USHORT 
//   col  2:  Name         oCol: 4, cbCol:2, string 
// =================================================
//  9(0x9): InterfaceImpl        cRecs:    0(0), cbRec:  4(0x4), cbTable:     0(0)
//   col  0:* Class        oCol: 0, cbCol:2, TypeDef
//   col  1:  Interface    oCol: 2, cbCol:2, TypeDefOrRef
// =================================================
// 10(0xa): MemberRef            cRecs:    7(0x7), cbRec:  6(0x6), cbTable:    42(0x2a)
//   col  0:  Class        oCol: 0, cbCol:2, MemberRefParent
//   col  1:  Name         oCol: 2, cbCol:2, string 
//   col  2:  Signature    oCol: 4, cbCol:2, blob   
// -------------------------------------------------
//    1 == 0:MemberRefParent[1b000001], 1:string#b1, 2:blob#aa
//    2 == 0:MemberRefParent[1b000001], 1:string#7d, 2:blob#ae
//    3 == 0:MemberRefParent[1b000001], 1:string#74, 2:blob#b6
//    4 == 0:MemberRefParent[01000003], 1:string#b7, 2:blob#bd
//    5 == 0:MemberRefParent[01000005], 1:string#c5, 2:blob#c4
//    6 == 0:MemberRefParent[01000005], 1:string#8d, 2:blob#c4
//    7 == 0:MemberRefParent[01000006], 1:string#b1, 2:blob#aa
// =================================================
// 11(0xb): Constant             cRecs:    0(0), cbRec:  6(0x6), cbTable:     0(0)
//   col  0:  Type         oCol: 0, cbCol:1, BYTE   
//   col  1:* Parent       oCol: 2, cbCol:2, HasConstant
//   col  2:  Value        oCol: 4, cbCol:2, blob   
// =================================================
// 12(0xc): CustomAttribute      cRecs:    0(0), cbRec:  6(0x6), cbTable:     0(0)
//   col  0:* Parent       oCol: 0, cbCol:2, HasCustomAttribute
//   col  1:  Type         oCol: 2, cbCol:2, CustomAttributeType
//   col  2:  Value        oCol: 4, cbCol:2, blob   
// =================================================
// 13(0xd): FieldMarshal         cRecs:    0(0), cbRec:  4(0x4), cbTable:     0(0)
//   col  0:* Parent       oCol: 0, cbCol:2, HasFieldMarshal
//   col  1:  NativeType   oCol: 2, cbCol:2, blob   
// =================================================
// 14(0xe): DeclSecurity         cRecs:    0(0), cbRec:  6(0x6), cbTable:     0(0)
//   col  0:  Action       oCol: 0, cbCol:2, short  
//   col  1:* Parent       oCol: 2, cbCol:2, HasDeclSecurity
//   col  2:  PermissionSet oCol: 4, cbCol:2, blob   
// =================================================
// 15(0xf): ClassLayout          cRecs:    0(0), cbRec:  8(0x8), cbTable:     0(0)
//   col  0:  PackingSize  oCol: 0, cbCol:2, USHORT 
//   col  1:  ClassSize    oCol: 2, cbCol:4, ULONG  
//   col  2:* Parent       oCol: 6, cbCol:2, TypeDef
// =================================================
// 16(0x10): FieldLayout          cRecs:    0(0), cbRec:  6(0x6), cbTable:     0(0)
//   col  0:  OffSet       oCol: 0, cbCol:4, ULONG  
//   col  1:* Field        oCol: 4, cbCol:2, Field  
// =================================================
// 17(0x11): StandAloneSig        cRecs:    1(0x1), cbRec:  2(0x2), cbTable:     2(0x2)
//   col  0:  Signature    oCol: 0, cbCol:2, blob   
// -------------------------------------------------
//    1 == 0:blob#ca
// =================================================
// 18(0x12): EventMap             cRecs:    0(0), cbRec:  4(0x4), cbTable:     0(0)
//   col  0:  Parent       oCol: 0, cbCol:2, TypeDef
//   col  1:  EventList    oCol: 2, cbCol:2, Event  
// =================================================
// 19(0x13): EventPtr             cRecs:    0(0), cbRec:  2(0x2), cbTable:     0(0)
//   col  0:  Event        oCol: 0, cbCol:2, Event  
// =================================================
// 20(0x14): Event                cRecs:    0(0), cbRec:  6(0x6), cbTable:     0(0)
//   col  0:  EventFlags   oCol: 0, cbCol:2, USHORT 
//   col  1:  Name         oCol: 2, cbCol:2, string 
//   col  2:  EventType    oCol: 4, cbCol:2, TypeDefOrRef
// =================================================
// 21(0x15): PropertyMap          cRecs:    0(0), cbRec:  4(0x4), cbTable:     0(0)
//   col  0:  Parent       oCol: 0, cbCol:2, TypeDef
//   col  1:  PropertyList oCol: 2, cbCol:2, Property
// =================================================
// 22(0x16): PropertyPtr          cRecs:    0(0), cbRec:  2(0x2), cbTable:     0(0)
//   col  0:  Property     oCol: 0, cbCol:2, Property
// =================================================
// 23(0x17): Property             cRecs:    0(0), cbRec:  6(0x6), cbTable:     0(0)
//   col  0:  PropFlags    oCol: 0, cbCol:2, USHORT 
//   col  1:  Name         oCol: 2, cbCol:2, string 
//   col  2:  Type         oCol: 4, cbCol:2, blob   
// =================================================
// 24(0x18): MethodSemantics      cRecs:    0(0), cbRec:  6(0x6), cbTable:     0(0)
//   col  0:  Semantic     oCol: 0, cbCol:2, USHORT 
//   col  1:  Method       oCol: 2, cbCol:2, Method 
//   col  2:* Association  oCol: 4, cbCol:2, HasSemantic
// =================================================
// 25(0x19): MethodImpl           cRecs:    0(0), cbRec:  6(0x6), cbTable:     0(0)
//   col  0:* Class        oCol: 0, cbCol:2, TypeDef
//   col  1:  MethodBody   oCol: 2, cbCol:2, MethodDefOrRef
//   col  2:  MethodDeclaration oCol: 4, cbCol:2, MethodDefOrRef
// =================================================
// 26(0x1a): ModuleRef            cRecs:    0(0), cbRec:  2(0x2), cbTable:     0(0)
//   col  0:  Name         oCol: 0, cbCol:2, string 
// =================================================
// 27(0x1b): TypeSpec             cRecs:    1(0x1), cbRec:  2(0x2), cbTable:     2(0x2)
//   col  0:  Signature    oCol: 0, cbCol:2, blob   
// -------------------------------------------------
//    1 == 0:blob#a3
// =================================================
// 28(0x1c): ImplMap              cRecs:    0(0), cbRec:  8(0x8), cbTable:     0(0)
//   col  0:  MappingFlags oCol: 0, cbCol:2, USHORT 
//   col  1:* MemberForwarded oCol: 2, cbCol:2, MemberForwarded
//   col  2:  ImportName   oCol: 4, cbCol:2, string 
//   col  3:  ImportScope  oCol: 6, cbCol:2, ModuleRef
// =================================================
// 29(0x1d): FieldRVA             cRecs:    0(0), cbRec:  6(0x6), cbTable:     0(0)
//   col  0:  RVA          oCol: 0, cbCol:4, ULONG  
//   col  1:* Field        oCol: 4, cbCol:2, Field  
// =================================================
// 30(0x1e): ENCLog               cRecs:    0(0), cbRec:  8(0x8), cbTable:     0(0)
//   col  0:  Token        oCol: 0, cbCol:4, ULONG  
//   col  1:  FuncCode     oCol: 4, cbCol:4, ULONG  
// =================================================
// 31(0x1f): ENCMap               cRecs:    0(0), cbRec:  4(0x4), cbTable:     0(0)
//   col  0:  Token        oCol: 0, cbCol:4, ULONG  
// =================================================
// 32(0x20): Assembly             cRecs:    1(0x1), cbRec: 22(0x16), cbTable:    22(0x16)
//   col  0:  HashAlgId    oCol: 0, cbCol:4, ULONG  
//   col  1:  MajorVersion oCol: 4, cbCol:2, USHORT 
//   col  2:  MinorVersion oCol: 6, cbCol:2, USHORT 
//   col  3:  BuildNumber  oCol: 8, cbCol:2, USHORT 
//   col  4:  RevisionNumber oCol: a, cbCol:2, USHORT 
//   col  5:  Flags        oCol: c, cbCol:4, ULONG  
//   col  6:  PublicKey    oCol:10, cbCol:2, blob   
//   col  7:  Name         oCol:12, cbCol:2, string 
//   col  8:  Locale       oCol:14, cbCol:2, string 
// -------------------------------------------------
//    1 == 0:00000000, 1:0000, 2:0000, 3:0000, 4:0000, 5:00000000, 6:blob#0, 7:string#a7, 8:string#0
// =================================================
// 33(0x21): AssemblyProcessor    cRecs:    0(0), cbRec:  4(0x4), cbTable:     0(0)
//   col  0:  Processor    oCol: 0, cbCol:4, ULONG  
// =================================================
// 34(0x22): AssemblyOS           cRecs:    0(0), cbRec: 12(0xc), cbTable:     0(0)
//   col  0:  OSPlatformId oCol: 0, cbCol:4, ULONG  
//   col  1:  OSMajorVersion oCol: 4, cbCol:4, ULONG  
//   col  2:  OSMinorVersion oCol: 8, cbCol:4, ULONG  
// =================================================
// 35(0x23): AssemblyRef          cRecs:    1(0x1), cbRec: 20(0x14), cbTable:    20(0x14)
//   col  0:  MajorVersion oCol: 0, cbCol:2, USHORT 
//   col  1:  MinorVersion oCol: 2, cbCol:2, USHORT 
//   col  2:  BuildNumber  oCol: 4, cbCol:2, USHORT 
//   col  3:  RevisionNumber oCol: 6, cbCol:2, USHORT 
//   col  4:  Flags        oCol: 8, cbCol:4, ULONG  
//   col  5:  PublicKeyOrToken oCol: c, cbCol:2, blob   
//   col  6:  Name         oCol: e, cbCol:2, string 
//   col  7:  Locale       oCol:10, cbCol:2, string 
//   col  8:  HashValue    oCol:12, cbCol:2, blob   
// -------------------------------------------------
//    1 == 0:0009, 1:0000, 2:0000, 3:0000, 4:00000001, 5:blob#1, 6:string#1d, 7:string#0, 8:blob#0
// =================================================
// 36(0x24): AssemblyRefProcessor cRecs:    0(0), cbRec:  6(0x6), cbTable:     0(0)
//   col  0:  Processor    oCol: 0, cbCol:4, ULONG  
//   col  1:  AssemblyRef  oCol: 4, cbCol:2, AssemblyRef
// =================================================
// 37(0x25): AssemblyRefOS        cRecs:    0(0), cbRec: 14(0xe), cbTable:     0(0)
//   col  0:  OSPlatformId oCol: 0, cbCol:4, ULONG  
//   col  1:  OSMajorVersion oCol: 4, cbCol:4, ULONG  
//   col  2:  OSMinorVersion oCol: 8, cbCol:4, ULONG  
//   col  3:  AssemblyRef  oCol: c, cbCol:2, AssemblyRef
// =================================================
// 38(0x26): File                 cRecs:    0(0), cbRec:  8(0x8), cbTable:     0(0)
//   col  0:  Flags        oCol: 0, cbCol:4, ULONG  
//   col  1:  Name         oCol: 4, cbCol:2, string 
//   col  2:  HashValue    oCol: 6, cbCol:2, blob   
// =================================================
// 39(0x27): ExportedType         cRecs:    0(0), cbRec: 14(0xe), cbTable:     0(0)
//   col  0:  Flags        oCol: 0, cbCol:4, ULONG  
//   col  1:  TypeDefId    oCol: 4, cbCol:4, ULONG  
//   col  2:  TypeName     oCol: 8, cbCol:2, string 
//   col  3:  TypeNamespace oCol: a, cbCol:2, string 
//   col  4:  Implementation oCol: c, cbCol:2, Implementation
// =================================================
// 40(0x28): ManifestResource     cRecs:    0(0), cbRec: 12(0xc), cbTable:     0(0)
//   col  0:  Offset       oCol: 0, cbCol:4, ULONG  
//   col  1:  Flags        oCol: 4, cbCol:4, ULONG  
//   col  2:  Name         oCol: 8, cbCol:2, string 
//   col  3:  Implementation oCol: a, cbCol:2, Implementation
// =================================================
// 41(0x29): NestedClass          cRecs:    0(0), cbRec:  4(0x4), cbTable:     0(0)
//   col  0:* NestedClass  oCol: 0, cbCol:2, TypeDef
//   col  1:  EnclosingClass oCol: 2, cbCol:2, TypeDef
// =================================================
// 42(0x2a): GenericParam         cRecs:    0(0), cbRec:  8(0x8), cbTable:     0(0)
//   col  0:  Number       oCol: 0, cbCol:2, USHORT 
//   col  1:  Flags        oCol: 2, cbCol:2, USHORT 
//   col  2:* Owner        oCol: 4, cbCol:2, TypeOrMethodDef
//   col  3:  Name         oCol: 6, cbCol:2, string 
// =================================================
// 43(0x2b): MethodSpec           cRecs:    0(0), cbRec:  4(0x4), cbTable:     0(0)
//   col  0:  Method       oCol: 0, cbCol:2, MethodDefOrRef
//   col  1:  Instantiation oCol: 2, cbCol:2, blob   
// =================================================
// 44(0x2c): GenericParamConstraint cRecs:    0(0), cbRec:  4(0x4), cbTable:     0(0)
//   col  0:* Owner        oCol: 0, cbCol:2, GenericParam
//   col  1:  Constraint   oCol: 2, cbCol:2, TypeDefOrRef
// ===========================================================
// ===========================================================
// ================================= END OF METAINFO ================================================


// Metadata version: v4.0.30319
.assembly extern /*23000001*/ System.Private.CoreLib
{
  .publickey = (00 24 00 00 04 80 00 00 94 00 00 00 06 02 00 00   // .$..............
                00 24 00 00 52 53 41 31 00 04 00 00 01 00 01 00   // .$..RSA1........
                8D 56 C7 6F 9E 86 49 38 30 49 F3 83 C4 4B E0 EC   // .V.o..I80I...K..
                20 41 81 82 2A 6C 31 CF 5E B7 EF 48 69 44 D0 32   //  A..*l1.^..HiD.2
                18 8E A1 D3 92 07 63 71 2C CB 12 D7 5F B7 7E 98   // ......cq,..._.~.
                11 14 9E 61 48 E5 D3 2F BA AB 37 61 1C 18 78 DD   // ...aH../..7a..x.
                C1 9E 20 EF 13 5D 0C B2 CF F2 BF EC 3D 11 58 10   // .. ..]......=.X.
                C3 D9 06 96 38 FE 4B E2 15 DB F7 95 86 19 20 E5   // ....8.K....... .
                AB 6F 7D B2 E2 CE EF 13 6A C2 3D 5D D2 BF 03 17   // .o}.....j.=]....
                00 AE C2 32 F6 C6 B1 C7 85 B4 30 5C 12 3B 37 AB ) // ...2......0\.;7.
  .ver 9:0:0:0
}
.assembly /*20000001*/ exiterror
{
  .ver 0:0:0:0
}
.module MainModule
// MVID: {38d54c22-7192-47f2-9a3f-0a4df116847c}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x000001C689540000


// =============== CLASS MEMBERS DECLARATION ===================

.class /*02000002*/ public auto ansi AtLangProgram
       extends [System.Private.CoreLib/*23000001*/]System.Object/*01000006*/
{
  .method /*06000001*/ public hidebysig static 
          int32  Main() cil managed
  // SIG: 00 00 08
  {
    .entrypoint
    // Method begins at RVA 0x2050
    // Code size       213 (0xd5)
    .maxstack  5
    .locals /*11000001*/ init (class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object> V_0)
    IL_0000:  /* 73   | (0A)000001       */ newobj     instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::.ctor() /* 0A000001 */
    IL_0005:  /* 0A   |                  */ stloc.0
    IL_0006:  /* 06   |                  */ ldloc.0
    IL_0007:  /* 72   | (70)000001       */ ldstr      "STATUS" /* 70000001 */
    IL_000c:  /* 72   | (70)00000F       */ ldstr      "Success" /* 7000000F */
    IL_0011:  /* 6F   | (0A)000002       */ callvirt   instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::set_Item(!0,
                                                                                                                                                                                                        !1) /* 0A000002 */
    IL_0016:  /* 06   |                  */ ldloc.0
    IL_0017:  /* 72   | (70)000001       */ ldstr      "STATUS" /* 70000001 */
    IL_001c:  /* 6F   | (0A)000003       */ callvirt   instance !1 class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::get_Item(!0) /* 0A000003 */
    IL_0021:  /* 25   |                  */ dup
    IL_0022:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.Int64/*01000002*/
    IL_0027:  /* 25   |                  */ dup
    IL_0028:  /* 2D   | 12               */ brtrue.s   IL_003c

    IL_002a:  /* 26   |                  */ pop
    IL_002b:  /* 25   |                  */ dup
    IL_002c:  /* 75   | (01)000003       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000003*/
    IL_0031:  /* 25   |                  */ dup
    IL_0032:  /* 2D   | 0F               */ brtrue.s   IL_0043

    IL_0034:  /* 26   |                  */ pop
    IL_0035:  /* 72   | (70)00001F       */ ldstr      "" /* 7000001F */
    IL_003a:  /* 2B   | 09               */ br.s       IL_0045

    IL_003c:  /* A5   | (01)000002       */ unbox.any  [System.Private.CoreLib/*23000001*/]System.Int64/*01000002*/
    IL_0041:  /* 2B   | 02               */ br.s       IL_0045

    IL_0043:  /* 2B   | 00               */ br.s       IL_0045

    IL_0045:  /* 06   |                  */ ldloc.0
    IL_0046:  /* 72   | (70)000001       */ ldstr      "STATUS" /* 70000001 */
    IL_004b:  /* 72   | (70)00000F       */ ldstr      "Success" /* 7000000F */
    IL_0050:  /* 6F   | (0A)000002       */ callvirt   instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::set_Item(!0,
                                                                                                                                                                                                        !1) /* 0A000002 */
    IL_0055:  /* 1A   |                  */ ldc.i4.4
    IL_0056:  /* 28   | (0A)000004       */ call       instance bool [System.Private.CoreLib/*23000001*/]System.String/*01000003*/::Equals(string,
                                                                                                                                           valuetype [System.Private.CoreLib/*23000001*/]System.StringComparison/*01000004*/) /* 0A000004 */
    IL_005b:  /* 39   | 0000003C         */ brfalse    IL_009c

    IL_0060:  /* 06   |                  */ ldloc.0
    IL_0061:  /* 72   | (70)000001       */ ldstr      "STATUS" /* 70000001 */
    IL_0066:  /* 21   | 0000000000000000 */ ldc.i8     0x0
    IL_006f:  /* 8C   | (01)000002       */ box        [System.Private.CoreLib/*23000001*/]System.Int64/*01000002*/
    IL_0074:  /* 6F   | (0A)000002       */ callvirt   instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::set_Item(!0,
                                                                                                                                                                                                        !1) /* 0A000002 */
    IL_0079:  /* 21   | 0000000000000000 */ ldc.i8     0x0
    IL_0082:  /* 28   | (0A)000005       */ call       int64 [System.Private.CoreLib/*23000001*/]System.Math/*01000005*/::Max(int64,
                                                                                                                              int64) /* 0A000005 */
    IL_0087:  /* 21   | 00000000000000FF */ ldc.i8     0xff
    IL_0090:  /* 28   | (0A)000006       */ call       int64 [System.Private.CoreLib/*23000001*/]System.Math/*01000005*/::Min(int64,
                                                                                                                              int64) /* 0A000006 */
    IL_0095:  /* 69   |                  */ conv.i4
    IL_0096:  /* 2A   |                  */ ret

    IL_0097:  /* 38   | 00000000         */ br         IL_009c

    IL_009c:  /* 06   |                  */ ldloc.0
    IL_009d:  /* 72   | (70)000001       */ ldstr      "STATUS" /* 70000001 */
    IL_00a2:  /* 21   | 000000000000007B */ ldc.i8     0x7b
    IL_00ab:  /* 8C   | (01)000002       */ box        [System.Private.CoreLib/*23000001*/]System.Int64/*01000002*/
    IL_00b0:  /* 6F   | (0A)000002       */ callvirt   instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::set_Item(!0,
                                                                                                                                                                                                        !1) /* 0A000002 */
    IL_00b5:  /* 21   | 0000000000000000 */ ldc.i8     0x0
    IL_00be:  /* 28   | (0A)000005       */ call       int64 [System.Private.CoreLib/*23000001*/]System.Math/*01000005*/::Max(int64,
                                                                                                                              int64) /* 0A000005 */
    IL_00c3:  /* 21   | 00000000000000FF */ ldc.i8     0xff
    IL_00cc:  /* 28   | (0A)000006       */ call       int64 [System.Private.CoreLib/*23000001*/]System.Math/*01000005*/::Min(int64,
                                                                                                                              int64) /* 0A000006 */
    IL_00d1:  /* 69   |                  */ conv.i4
    IL_00d2:  /* 2A   |                  */ ret

    IL_00d3:  /* 16   |                  */ ldc.i4.0
    IL_00d4:  /* 2A   |                  */ ret
  } // end of method AtLangProgram::Main

  .method /*06000002*/ public specialname rtspecialname 
          instance void  .ctor() cil managed
  // SIG: 20 00 01
  {
    // Method begins at RVA 0x2131
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  /* 02   |                  */ ldarg.0
    IL_0001:  /* 28   | (0A)000007       */ call       instance void [System.Private.CoreLib/*23000001*/]System.Object/*01000006*/::.ctor() /* 0A000007 */
    IL_0006:  /* 2A   |                  */ ret
  } // end of method AtLangProgram::.ctor

} // end of class AtLangProgram


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
