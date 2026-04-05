
//  .NET IL Disassembler.  Version 9.0.6


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
// Time-date stamp:            0x69d2beed
// Ptr to symbol table:        0x00000000
// Number of symbols:          0x00000000
// Size of optional header:    0x00e0
// Characteristics:            0x0002
// ----- PE Optional Header (32 bit):
// Magic:                          0x010b
// Major linker version:           0x30
// Minor linker version:           0x00
// Size of code:                   0x00000c00
// Size of init.data:              0x00000200
// Size of uninit.data:            0x00000000
// Addr. of entry point:           0x00002abe
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
// 0x00002a6c [0x0000004f] address [size] of Import Directory:          
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
//              0x00000ac4 Virtual Size
//              0x00002000 Virtual Address
//              0x00000c00 Size of Raw Data
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
//              0x00000e00 Pointer to Raw Data
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
//              Entry 1: Type 0x3 Offset 0x00000ac0
//              Entry 2: Type 0x0 Offset 0x00000000

// Import Address Table
//     DLL : mscoree.dll
//              0x00002000 Import Address Table
//              0x00002aae Import Name Table
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
// 0x000022d8 [0x00000714] address [size] of Metadata Directory:        
// Flags:                              0x00000001
// Entry point token:                  0x06000001
// 0x00000000 [0x00000000] address [size] of Resources Directory:       
// 0x000029ec [0x00000080] address [size] of Strong Name Signature:     
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
//              0x0000017c Size
//              '#~' Name
//    Stream 2:
//              0x000001e8 Offset
//              0x00000158 Size
//              '#Strings' Name
//    Stream 3:
//              0x00000340 Offset
//              0x00000184 Size
//              '#US' Name
//    Stream 4:
//              0x000004c4 Offset
//              0x00000010 Size
//              '#GUID' Name
//    Stream 5:
//              0x000004d4 Offset
//              0x00000240 Size
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

// File size            : 4096
// PE header size       : 512 (456 used)    (12.50%)
// PE additional info   : 171               ( 4.17%)
// Num.of PE sections   : 2
// CLR header size     : 72                 ( 1.76%)
// CLR meta-data size  : 1812               (44.24%)
// CLR additional info : 128                ( 3.12%)
// CLR method headers  : 13                 ( 0.32%)
// Managed code         : 635               (15.50%)
// Data                 : 512               (12.50%)
// Unaccounted          : 241               ( 5.88%)

// Num.of PE sections   : 2
//   .text    - 3072
//   .reloc   - 512

// CLR meta-data size  : 1812
//   Module        -    1 (10 bytes)
//   TypeDef       -    2 (28 bytes)      0 interfaces, 0 explicit layout
//   TypeRef       -    8 (48 bytes)
//   MethodDef     -    2 (28 bytes)      0 abstract, 0 native, 2 bodies
//   MemberRef     -   16 (96 bytes)
//   StandAloneSig -    1 (2 bytes)
//   TypeSpec      -    1 (2 bytes)
//   Assembly      -    1 (22 bytes)
//   AssemblyRef   -    4 (80 bytes)
//   Strings       -   343 bytes
//   Blobs         -   576 bytes
//   UserStrings   -   388 bytes
//   Guids         -    16 bytes
//   Uncategorized -   173 bytes

// CLR additional info : 128

// CLR method headers : 13
//   Num.of method bodies  - 2
//   Num.of fat headers    - 1
//   Num.of tiny headers   - 1

// Managed code : 635
//   Ave method size - 317
// Classes defined in this module:
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// Class AtLangProgram                  (public) (auto) (ansi) 
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

// ================================= M E T A I N F O ================================================

// ===========================================================
// Metadata section: 0x424a5342, version: 1.1, extra: 0, version len: 12, version: v4.0.30319
//            flags: 0x00, streams: 5
// Stream 0: name: #~, size 380
// Stream 1: name: #Strings, size 344
// Stream 2: name: #US, size 388
// Stream 3: name: #GUID, size 16
// Stream 4: name: #Blob, size 576
// Metadata header: 2.0, heaps: 0x00, rid: 0x01, valid: 0x0000000908020447, sorted: 0x000016003301fa00
// 
// Strings: 343(0x157), Blobs: 576(0x240), Guids: 16(0x10), User strings: 388(0x184)
// =================================================
//  0(0): Module               cRecs:    1(0x1), cbRec: 10(0xa), cbTable:    10(0xa)
//   col  0:  Generation   oCol: 0, cbCol:2, USHORT 
//   col  1:  Name         oCol: 2, cbCol:2, string 
//   col  2:  Mvid         oCol: 4, cbCol:2, GUID   
//   col  3:  EncId        oCol: 6, cbCol:2, GUID   
//   col  4:  EncBaseId    oCol: 8, cbCol:2, GUID   
// -------------------------------------------------
//    1 == 0:0000, 1:string#62, 2:guid#1, 3:guid#0, 4:guid#0
// =================================================
//  1(0x1): TypeRef              cRecs:    8(0x8), cbRec:  6(0x6), cbTable:    48(0x30)
//   col  0:  ResolutionScope oCol: 0, cbCol:2, ResolutionScope
//   col  1:  Name         oCol: 2, cbCol:2, string 
//   col  2:  Namespace    oCol: 4, cbCol:2, string 
// -------------------------------------------------
//    1 == 0:ResolutionScope[23000001], 1:string#1, 2:string#38
//    2 == 0:ResolutionScope[23000001], 1:string#8c, 2:string#da
//    3 == 0:ResolutionScope[23000002], 1:string#125, 2:string#10f
//    4 == 0:ResolutionScope[23000003], 1:string#b6, 2:string#da
//    5 == 0:ResolutionScope[23000001], 1:string#e6, 2:string#da
//    6 == 0:ResolutionScope[23000004], 1:string#5a, 2:string#da
//    7 == 0:ResolutionScope[23000001], 1:string#f0, 2:string#17
//    8 == 0:ResolutionScope[23000001], 1:string#108, 2:string#da
// =================================================
//  2(0x2): TypeDef              cRecs:    2(0x2), cbRec: 14(0xe), cbTable:    28(0x1c)
//   col  0:  Flags        oCol: 0, cbCol:4, ULONG  
//   col  1:  Name         oCol: 4, cbCol:2, string 
//   col  2:  Namespace    oCol: 6, cbCol:2, string 
//   col  3:  Extends      oCol: 8, cbCol:2, TypeDefOrRef
//   col  4:  FieldList    oCol: a, cbCol:2, Field  
//   col  5:  MethodList   oCol: c, cbCol:2, Method 
// -------------------------------------------------
//    1 == 0:00000000, 1:string#e, 2:string#0, 3:TypeDefOrRef[02000000], 4:Field[4000001], 5:Method[6000001]
//    2 == 0:00000001, 1:string#ba, 2:string#0, 3:TypeDefOrRef[01000008], 4:Field[4000001], 5:Method[6000001]
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
//    1 == 0:00002050, 1:0000, 2:0096, 3:string#e1, 4:blob#23c, 5:Param[8000001]
//    2 == 0:000022d0, 1:0000, 2:1806, 3:string#fb, 4:blob#aa, 5:Param[8000001]
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
// 10(0xa): MemberRef            cRecs:   16(0x10), cbRec:  6(0x6), cbTable:    96(0x60)
//   col  0:  Class        oCol: 0, cbCol:2, MemberRefParent
//   col  1:  Name         oCol: 2, cbCol:2, string 
//   col  2:  Signature    oCol: 4, cbCol:2, blob   
// -------------------------------------------------
//    1 == 0:MemberRefParent[1b000001], 1:string#fb, 2:blob#aa
//    2 == 0:MemberRefParent[1b000001], 1:string#d1, 2:blob#ae
//    3 == 0:MemberRefParent[01000003], 1:string#fb, 2:blob#aa
//    4 == 0:MemberRefParent[1b000001], 1:string#c8, 2:blob#158
//    5 == 0:MemberRefParent[01000004], 1:string#fb, 2:blob#201
//    6 == 0:MemberRefParent[01000004], 1:string#13a, 2:blob#206
//    7 == 0:MemberRefParent[01000002], 1:string#14b, 2:blob#20a
//    8 == 0:MemberRefParent[01000002], 1:string#93, 2:blob#210
//    9 == 0:MemberRefParent[01000002], 1:string#9c, 2:blob#210
//    a == 0:MemberRefParent[01000005], 1:string#fb, 2:blob#201
//    b == 0:MemberRefParent[01000003], 1:string#77, 2:blob#215
//    c == 0:MemberRefParent[01000006], 1:string#143, 2:blob#21a
//    d == 0:MemberRefParent[01000002], 1:string#101, 2:blob#21f
//    e == 0:MemberRefParent[01000007], 1:string#6d, 2:blob#201
//    f == 0:MemberRefParent[01000003], 1:string#86, 2:blob#225
//   10 == 0:MemberRefParent[01000008], 1:string#fb, 2:blob#aa
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
//    1 == 0:blob#22b
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
//    1 == 0:00000000, 1:0000, 2:0000, 3:0000, 4:0000, 5:00000000, 6:blob#0, 7:string#12f, 8:string#0
// =================================================
// 33(0x21): AssemblyProcessor    cRecs:    0(0), cbRec:  4(0x4), cbTable:     0(0)
//   col  0:  Processor    oCol: 0, cbCol:4, ULONG  
// =================================================
// 34(0x22): AssemblyOS           cRecs:    0(0), cbRec: 12(0xc), cbTable:     0(0)
//   col  0:  OSPlatformId oCol: 0, cbCol:4, ULONG  
//   col  1:  OSMajorVersion oCol: 4, cbCol:4, ULONG  
//   col  2:  OSMinorVersion oCol: 8, cbCol:4, ULONG  
// =================================================
// 35(0x23): AssemblyRef          cRecs:    4(0x4), cbRec: 20(0x14), cbTable:    80(0x50)
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
//    1 == 0:0009, 1:0000, 2:0000, 3:0000, 4:00000001, 5:blob#1, 6:string#21, 7:string#0, 8:blob#0
//    2 == 0:0009, 1:0000, 2:0000, 3:0000, 4:00000001, 5:blob#b6, 6:string#11a, 7:string#0, 8:blob#0
//    3 == 0:0009, 1:0000, 2:0000, 3:0000, 4:00000001, 5:blob#15f, 6:string#a7, 7:string#0, 8:blob#0
//    4 == 0:0009, 1:0000, 2:0000, 3:0000, 4:00000001, 5:blob#15f, 6:string#53, 7:string#0, 8:blob#0
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
.assembly extern /*23000002*/ System.Net.WebClient
{
  .publickey = (00 24 00 00 04 80 00 00 94 00 00 00 06 02 00 00   // .$..............
                00 24 00 00 52 53 41 31 00 04 00 00 01 00 01 00   // .$..RSA1........
                4B 86 C4 CB 78 54 9B 34 BA B6 1A 3B 18 00 E2 3B   // K...xT.4...;...;
                FE B5 B3 EC 39 00 74 04 15 36 A7 E3 CB D9 7F 5F   // ....9.t..6....._
                04 CF 0F 85 71 55 A8 92 8E AA 29 EB FD 11 CF BB   // ....qU....).....
                AD 3B A7 0E FE A7 BD A3 22 6C 6A 8D 37 0A 4C D3   // .;......"lj.7.L.
                03 F7 14 48 6B 6E BC 22 59 85 A6 38 47 1E 6E F5   // ...Hkn."Y..8G.n.
                71 CC 92 A4 61 3C 00 B8 FA 65 D6 1C CE E0 CB E5   // q...a<...e......
                F3 63 30 C9 A0 1F 41 83 55 9F 1B EF 24 CC 29 17   // .c0...A.U...$.).
                C6 D9 13 E3 A5 41 33 3A 1D 05 D9 BE D2 2B 38 CB ) // .....A3:.....+8.
  .ver 9:0:0:0
}
.assembly extern /*23000003*/ System.Private.Uri
{
  .publickey = (00 24 00 00 04 80 00 00 94 00 00 00 06 02 00 00   // .$..............
                00 24 00 00 52 53 41 31 00 04 00 00 01 00 01 00   // .$..RSA1........
                07 D1 FA 57 C4 AE D9 F0 A3 2E 84 AA 0F AE FD 0D   // ...W............
                E9 E8 FD 6A EC 8F 87 FB 03 76 6C 83 4C 99 92 1E   // ...j.....vl.L...
                B2 3B E7 9A D9 D5 DC C1 DD 9A D2 36 13 21 02 90   // .;.........6.!..
                0B 72 3C F9 80 95 7F C4 E1 77 10 8F C6 07 77 4F   // .r<......w....wO
                29 E8 32 0E 92 EA 05 EC E4 E8 21 C0 A5 EF E8 F1   // ).2.......!.....
                64 5C 4C 0C 93 C1 AB 99 28 5D 62 2C AA 65 2C 1D   // d\L.....(]b,.e,.
                FA D6 3D 74 5D 6F 2D E5 F1 7E 5E AF 0F C4 96 3D   // ..=t]o-..~^....=
                26 1C 8A 12 43 65 18 20 6D C0 93 34 4D 5A D2 93 ) // &...Ce. m..4MZ..
  .ver 9:0:0:0
}
.assembly extern /*23000004*/ System.Console
{
  .publickey = (00 24 00 00 04 80 00 00 94 00 00 00 06 02 00 00   // .$..............
                00 24 00 00 52 53 41 31 00 04 00 00 01 00 01 00   // .$..RSA1........
                07 D1 FA 57 C4 AE D9 F0 A3 2E 84 AA 0F AE FD 0D   // ...W............
                E9 E8 FD 6A EC 8F 87 FB 03 76 6C 83 4C 99 92 1E   // ...j.....vl.L...
                B2 3B E7 9A D9 D5 DC C1 DD 9A D2 36 13 21 02 90   // .;.........6.!..
                0B 72 3C F9 80 95 7F C4 E1 77 10 8F C6 07 77 4F   // .r<......w....wO
                29 E8 32 0E 92 EA 05 EC E4 E8 21 C0 A5 EF E8 F1   // ).2.......!.....
                64 5C 4C 0C 93 C1 AB 99 28 5D 62 2C AA 65 2C 1D   // d\L.....(]b,.e,.
                FA D6 3D 74 5D 6F 2D E5 F1 7E 5E AF 0F C4 96 3D   // ..=t]o-..~^....=
                26 1C 8A 12 43 65 18 20 6D C0 93 34 4D 5A D2 93 ) // &...Ce. m..4MZ..
  .ver 9:0:0:0
}
.assembly /*20000001*/ webrequest
{
  .ver 0:0:0:0
}
.module MainModule
// MVID: {6f36c51e-0e6e-4903-96b0-d2d4ad48a70e}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x000002674CD20000


// =============== CLASS MEMBERS DECLARATION ===================

.class /*02000002*/ public auto ansi AtLangProgram
       extends [System.Private.CoreLib/*23000001*/]System.Object/*01000008*/
{
  .method /*06000001*/ public hidebysig static 
          int32  Main() cil managed
  // SIG: 00 00 08
  {
    .entrypoint
    // Method begins at RVA 0x2050
    // Code size       628 (0x274)
    .maxstack  6
    .locals /*11000001*/ init (class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object> V_0,
             string V_1,
             class [System.Private.Uri/*23000003*/]System.Uri/*01000004*/ V_2,
             string V_3,
             string V_4,
             class [System.Private.Uri/*23000003*/]System.Uri/*01000004*/ V_5,
             string V_6)
    IL_0000:  /* 73   | (0A)000001       */ newobj     instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::.ctor() /* 0A000001 */
    IL_0005:  /* 0A   |                  */ stloc.0
    IL_0006:  /* 06   |                  */ ldloc.0
    IL_0007:  /* 72   | (70)000001       */ ldstr      "IPURL" /* 70000001 */
    IL_000c:  /* 72   | (70)00000D       */ ldstr      "https://ip.billywr.com/ip.txt" /* 7000000D */
    IL_0011:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_0016:  /* 6F   | (0A)000002       */ callvirt   instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::set_Item(!0,
                                                                                                                                                                                                        !1) /* 0A000002 */
    IL_001b:  /* 06   |                  */ ldloc.0
    IL_001c:  /* 72   | (70)000049       */ ldstr      "IP" /* 70000049 */
    IL_0021:  /* 73   | (0A)000003       */ newobj     instance void [System.Net.WebClient/*23000002*/]System.Net.WebClient/*01000003*/::.ctor() /* 0A000003 */
    IL_0026:  /* 06   |                  */ ldloc.0
    IL_0027:  /* 72   | (70)000001       */ ldstr      "IPURL" /* 70000001 */
    IL_002c:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_0031:  /* 6F   | (0A)000004       */ callvirt   instance !1 class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::get_Item(!0) /* 0A000004 */
    IL_0036:  /* 74   | (01)000002       */ castclass  [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_003b:  /* 0B   |                  */ stloc.1
    IL_003c:  /* 07   |                  */ ldloc.1
    IL_003d:  /* 73   | (0A)000005       */ newobj     instance void [System.Private.Uri/*23000003*/]System.Uri/*01000004*/::.ctor(string) /* 0A000005 */
    IL_0042:  /* 0C   |                  */ stloc.2
    IL_0043:  /* 08   |                  */ ldloc.2
    IL_0044:  /* 6F   | (0A)000006       */ callvirt   instance string [System.Private.Uri/*23000003*/]System.Uri/*01000004*/::get_Host() /* 0A000006 */
    IL_0049:  /* 0D   |                  */ stloc.3
    IL_004a:  /* 09   |                  */ ldloc.3
    IL_004b:  /* 72   | (70)00004F       */ ldstr      "localhost" /* 7000004F */
    IL_0050:  /* 28   | (0A)000007       */ call       bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::op_Equality(string,
                                                                                                                                       string) /* 0A000007 */
    IL_0055:  /* 3A   | 00000065         */ brtrue     IL_00bf

    IL_005a:  /* 09   |                  */ ldloc.3
    IL_005b:  /* 72   | (70)000063       */ ldstr      "127.0.0.1" /* 70000063 */
    IL_0060:  /* 28   | (0A)000007       */ call       bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::op_Equality(string,
                                                                                                                                       string) /* 0A000007 */
    IL_0065:  /* 3A   | 00000055         */ brtrue     IL_00bf

    IL_006a:  /* 09   |                  */ ldloc.3
    IL_006b:  /* 72   | (70)000077       */ ldstr      ".local" /* 70000077 */
    IL_0070:  /* 6F   | (0A)000008       */ callvirt   instance bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::EndsWith(string) /* 0A000008 */
    IL_0075:  /* 3A   | 00000045         */ brtrue     IL_00bf

    IL_007a:  /* 09   |                  */ ldloc.3
    IL_007b:  /* 72   | (70)000085       */ ldstr      "10." /* 70000085 */
    IL_0080:  /* 6F   | (0A)000009       */ callvirt   instance bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::StartsWith(string) /* 0A000009 */
    IL_0085:  /* 3A   | 00000035         */ brtrue     IL_00bf

    IL_008a:  /* 09   |                  */ ldloc.3
    IL_008b:  /* 72   | (70)00008D       */ ldstr      "192.168." /* 7000008D */
    IL_0090:  /* 6F   | (0A)000009       */ callvirt   instance bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::StartsWith(string) /* 0A000009 */
    IL_0095:  /* 3A   | 00000025         */ brtrue     IL_00bf

    IL_009a:  /* 09   |                  */ ldloc.3
    IL_009b:  /* 72   | (70)00009F       */ ldstr      "172.16." /* 7000009F */
    IL_00a0:  /* 6F   | (0A)000009       */ callvirt   instance bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::StartsWith(string) /* 0A000009 */
    IL_00a5:  /* 3A   | 00000015         */ brtrue     IL_00bf

    IL_00aa:  /* 09   |                  */ ldloc.3
    IL_00ab:  /* 72   | (70)0000AF       */ ldstr      "169.254.169.254" /* 700000AF */
    IL_00b0:  /* 28   | (0A)000007       */ call       bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::op_Equality(string,
                                                                                                                                       string) /* 0A000007 */
    IL_00b5:  /* 3A   | 00000005         */ brtrue     IL_00bf

    IL_00ba:  /* 38   | 0000000B         */ br         IL_00ca

    IL_00bf:  /* 72   | (70)0000CF       */ ldstr      "Blocked: URL points to restricted address" /* 700000CF */
    IL_00c4:  /* 73   | (0A)00000A       */ newobj     instance void [System.Private.CoreLib/*23000001*/]System.Exception/*01000005*/::.ctor(string) /* 0A00000A */
    IL_00c9:  /* 7A   |                  */ throw

    IL_00ca:  /* 07   |                  */ ldloc.1
    IL_00cb:  /* 6F   | (0A)00000B       */ callvirt   instance string [System.Net.WebClient/*23000002*/]System.Net.WebClient/*01000003*/::DownloadString(string) /* 0A00000B */
    IL_00d0:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_00d5:  /* 6F   | (0A)000002       */ callvirt   instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::set_Item(!0,
                                                                                                                                                                                                        !1) /* 0A000002 */
    IL_00da:  /* 06   |                  */ ldloc.0
    IL_00db:  /* 72   | (70)000123       */ ldstr      "IPTEXT" /* 70000123 */
    IL_00e0:  /* 72   | (70)000131       */ ldstr      "Your IP is " /* 70000131 */
    IL_00e5:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_00ea:  /* 6F   | (0A)000002       */ callvirt   instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::set_Item(!0,
                                                                                                                                                                                                        !1) /* 0A000002 */
    IL_00ef:  /* 28   | (0A)00000C       */ call       class [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/ [System.Console/*23000004*/]System.Console/*01000006*/::get_Out() /* 0A00000C */
    IL_00f4:  /* 06   |                  */ ldloc.0
    IL_00f5:  /* 72   | (70)000123       */ ldstr      "IPTEXT" /* 70000123 */
    IL_00fa:  /* 6F   | (0A)000004       */ callvirt   instance !1 class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::get_Item(!0) /* 0A000004 */
    IL_00ff:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_0104:  /* 25   |                  */ dup
    IL_0105:  /* 2D   | 06               */ brtrue.s   IL_010d

    IL_0107:  /* 26   |                  */ pop
    IL_0108:  /* 72   | (70)000149       */ ldstr      "" /* 70000149 */
    IL_010d:  /* 06   |                  */ ldloc.0
    IL_010e:  /* 72   | (70)000049       */ ldstr      "IP" /* 70000049 */
    IL_0113:  /* 6F   | (0A)000004       */ callvirt   instance !1 class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::get_Item(!0) /* 0A000004 */
    IL_0118:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_011d:  /* 25   |                  */ dup
    IL_011e:  /* 2D   | 06               */ brtrue.s   IL_0126

    IL_0120:  /* 26   |                  */ pop
    IL_0121:  /* 72   | (70)000149       */ ldstr      "" /* 70000149 */
    IL_0126:  /* 28   | (0A)00000D       */ call       string [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::Concat(string,
                                                                                                                                    string) /* 0A00000D */
    IL_012b:  /* 6F   | (0A)00000E       */ callvirt   instance void [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/::WriteLine(string) /* 0A00000E */
    IL_0130:  /* 06   |                  */ ldloc.0
    IL_0131:  /* 72   | (70)00014B       */ ldstr      "POSTDATA" /* 7000014B */
    IL_0136:  /* 72   | (70)00015D       */ ldstr      "[]" /* 7000015D */
    IL_013b:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_0140:  /* 6F   | (0A)000002       */ callvirt   instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::set_Item(!0,
                                                                                                                                                                                                        !1) /* 0A000002 */
    IL_0145:  /* 06   |                  */ ldloc.0
    IL_0146:  /* 72   | (70)000049       */ ldstr      "IP" /* 70000049 */
    IL_014b:  /* 73   | (0A)000003       */ newobj     instance void [System.Net.WebClient/*23000002*/]System.Net.WebClient/*01000003*/::.ctor() /* 0A000003 */
    IL_0150:  /* 06   |                  */ ldloc.0
    IL_0151:  /* 72   | (70)000001       */ ldstr      "IPURL" /* 70000001 */
    IL_0156:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_015b:  /* 6F   | (0A)000004       */ callvirt   instance !1 class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::get_Item(!0) /* 0A000004 */
    IL_0160:  /* 74   | (01)000002       */ castclass  [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_0165:  /* 13   | 04               */ stloc.s    V_4
    IL_0167:  /* 11   | 04               */ ldloc.s    V_4
    IL_0169:  /* 73   | (0A)000005       */ newobj     instance void [System.Private.Uri/*23000003*/]System.Uri/*01000004*/::.ctor(string) /* 0A000005 */
    IL_016e:  /* 13   | 05               */ stloc.s    V_5
    IL_0170:  /* 11   | 05               */ ldloc.s    V_5
    IL_0172:  /* 6F   | (0A)000006       */ callvirt   instance string [System.Private.Uri/*23000003*/]System.Uri/*01000004*/::get_Host() /* 0A000006 */
    IL_0177:  /* 13   | 06               */ stloc.s    V_6
    IL_0179:  /* 11   | 06               */ ldloc.s    V_6
    IL_017b:  /* 72   | (70)00004F       */ ldstr      "localhost" /* 7000004F */
    IL_0180:  /* 28   | (0A)000007       */ call       bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::op_Equality(string,
                                                                                                                                       string) /* 0A000007 */
    IL_0185:  /* 3A   | 0000006B         */ brtrue     IL_01f5

    IL_018a:  /* 11   | 06               */ ldloc.s    V_6
    IL_018c:  /* 72   | (70)000063       */ ldstr      "127.0.0.1" /* 70000063 */
    IL_0191:  /* 28   | (0A)000007       */ call       bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::op_Equality(string,
                                                                                                                                       string) /* 0A000007 */
    IL_0196:  /* 3A   | 0000005A         */ brtrue     IL_01f5

    IL_019b:  /* 11   | 06               */ ldloc.s    V_6
    IL_019d:  /* 72   | (70)000077       */ ldstr      ".local" /* 70000077 */
    IL_01a2:  /* 6F   | (0A)000008       */ callvirt   instance bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::EndsWith(string) /* 0A000008 */
    IL_01a7:  /* 3A   | 00000049         */ brtrue     IL_01f5

    IL_01ac:  /* 11   | 06               */ ldloc.s    V_6
    IL_01ae:  /* 72   | (70)000085       */ ldstr      "10." /* 70000085 */
    IL_01b3:  /* 6F   | (0A)000009       */ callvirt   instance bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::StartsWith(string) /* 0A000009 */
    IL_01b8:  /* 3A   | 00000038         */ brtrue     IL_01f5

    IL_01bd:  /* 11   | 06               */ ldloc.s    V_6
    IL_01bf:  /* 72   | (70)00008D       */ ldstr      "192.168." /* 7000008D */
    IL_01c4:  /* 6F   | (0A)000009       */ callvirt   instance bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::StartsWith(string) /* 0A000009 */
    IL_01c9:  /* 3A   | 00000027         */ brtrue     IL_01f5

    IL_01ce:  /* 11   | 06               */ ldloc.s    V_6
    IL_01d0:  /* 72   | (70)00009F       */ ldstr      "172.16." /* 7000009F */
    IL_01d5:  /* 6F   | (0A)000009       */ callvirt   instance bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::StartsWith(string) /* 0A000009 */
    IL_01da:  /* 3A   | 00000016         */ brtrue     IL_01f5

    IL_01df:  /* 11   | 06               */ ldloc.s    V_6
    IL_01e1:  /* 72   | (70)0000AF       */ ldstr      "169.254.169.254" /* 700000AF */
    IL_01e6:  /* 28   | (0A)000007       */ call       bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::op_Equality(string,
                                                                                                                                       string) /* 0A000007 */
    IL_01eb:  /* 3A   | 00000005         */ brtrue     IL_01f5

    IL_01f0:  /* 38   | 0000000B         */ br         IL_0200

    IL_01f5:  /* 72   | (70)0000CF       */ ldstr      "Blocked: URL points to restricted address" /* 700000CF */
    IL_01fa:  /* 73   | (0A)00000A       */ newobj     instance void [System.Private.CoreLib/*23000001*/]System.Exception/*01000005*/::.ctor(string) /* 0A00000A */
    IL_01ff:  /* 7A   |                  */ throw

    IL_0200:  /* 11   | 04               */ ldloc.s    V_4
    IL_0202:  /* 06   |                  */ ldloc.0
    IL_0203:  /* 72   | (70)00014B       */ ldstr      "POSTDATA" /* 7000014B */
    IL_0208:  /* 6F   | (0A)000004       */ callvirt   instance !1 class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::get_Item(!0) /* 0A000004 */
    IL_020d:  /* 6F   | (0A)00000F       */ callvirt   instance string [System.Net.WebClient/*23000002*/]System.Net.WebClient/*01000003*/::UploadString(string,
                                                                                                                                                        string) /* 0A00000F */
    IL_0212:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_0217:  /* 6F   | (0A)000002       */ callvirt   instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::set_Item(!0,
                                                                                                                                                                                                        !1) /* 0A000002 */
    IL_021c:  /* 06   |                  */ ldloc.0
    IL_021d:  /* 72   | (70)000123       */ ldstr      "IPTEXT" /* 70000123 */
    IL_0222:  /* 72   | (70)000163       */ ldstr      "POST response: " /* 70000163 */
    IL_0227:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_022c:  /* 6F   | (0A)000002       */ callvirt   instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::set_Item(!0,
                                                                                                                                                                                                        !1) /* 0A000002 */
    IL_0231:  /* 28   | (0A)00000C       */ call       class [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/ [System.Console/*23000004*/]System.Console/*01000006*/::get_Out() /* 0A00000C */
    IL_0236:  /* 06   |                  */ ldloc.0
    IL_0237:  /* 72   | (70)000123       */ ldstr      "IPTEXT" /* 70000123 */
    IL_023c:  /* 6F   | (0A)000004       */ callvirt   instance !1 class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::get_Item(!0) /* 0A000004 */
    IL_0241:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_0246:  /* 25   |                  */ dup
    IL_0247:  /* 2D   | 06               */ brtrue.s   IL_024f

    IL_0249:  /* 26   |                  */ pop
    IL_024a:  /* 72   | (70)000149       */ ldstr      "" /* 70000149 */
    IL_024f:  /* 06   |                  */ ldloc.0
    IL_0250:  /* 72   | (70)000049       */ ldstr      "IP" /* 70000049 */
    IL_0255:  /* 6F   | (0A)000004       */ callvirt   instance !1 class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::get_Item(!0) /* 0A000004 */
    IL_025a:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_025f:  /* 25   |                  */ dup
    IL_0260:  /* 2D   | 06               */ brtrue.s   IL_0268

    IL_0262:  /* 26   |                  */ pop
    IL_0263:  /* 72   | (70)000149       */ ldstr      "" /* 70000149 */
    IL_0268:  /* 28   | (0A)00000D       */ call       string [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::Concat(string,
                                                                                                                                    string) /* 0A00000D */
    IL_026d:  /* 6F   | (0A)00000E       */ callvirt   instance void [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/::WriteLine(string) /* 0A00000E */
    IL_0272:  /* 16   |                  */ ldc.i4.0
    IL_0273:  /* 2A   |                  */ ret
  } // end of method AtLangProgram::Main

  .method /*06000002*/ public specialname rtspecialname 
          instance void  .ctor() cil managed
  // SIG: 20 00 01
  {
    // Method begins at RVA 0x22d0
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  /* 02   |                  */ ldarg.0
    IL_0001:  /* 28   | (0A)000010       */ call       instance void [System.Private.CoreLib/*23000001*/]System.Object/*01000008*/::.ctor() /* 0A000010 */
    IL_0006:  /* 2A   |                  */ ret
  } // end of method AtLangProgram::.ctor

} // end of class AtLangProgram


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
