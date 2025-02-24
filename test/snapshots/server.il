
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
// Time-date stamp:            0x67bc6905
// Ptr to symbol table:        0x00000000
// Number of symbols:          0x00000000
// Size of optional header:    0x00e0
// Characteristics:            0x0002
// ----- PE Optional Header (32 bit):
// Magic:                          0x010b
// Major linker version:           0x30
// Minor linker version:           0x00
// Size of code:                   0x00001000
// Size of init.data:              0x00000200
// Size of uninit.data:            0x00000000
// Addr. of entry point:           0x00002f16
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
// 0x00002ec4 [0x0000004f] address [size] of Import Directory:          
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
//              0x00000f1c Virtual Size
//              0x00002000 Virtual Address
//              0x00001000 Size of Raw Data
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
//              0x00001200 Pointer to Raw Data
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
//              Entry 1: Type 0x3 Offset 0x00000f18
//              Entry 2: Type 0x0 Offset 0x00000000

// Import Address Table
//     DLL : mscoree.dll
//              0x00002000 Import Address Table
//              0x00002f06 Import Name Table
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
// 0x000022d0 [0x00000b74] address [size] of Metadata Directory:        
// Flags:                              0x00000001
// Entry point token:                  0x06000001
// 0x00000000 [0x00000000] address [size] of Resources Directory:       
// 0x00002e44 [0x00000080] address [size] of Strong Name Signature:     
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
//              0x00000288 Size
//              '#~' Name
//    Stream 2:
//              0x000002f4 Offset
//              0x00000334 Size
//              '#Strings' Name
//    Stream 3:
//              0x00000628 Offset
//              0x000001e8 Size
//              '#US' Name
//    Stream 4:
//              0x00000810 Offset
//              0x00000010 Size
//              '#GUID' Name
//    Stream 5:
//              0x00000820 Offset
//              0x00000354 Size
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

// File size            : 5120
// PE header size       : 512 (456 used)    (10.00%)
// PE additional info   : 171               ( 3.34%)
// Num.of PE sections   : 2
// CLR header size     : 72                 ( 1.41%)
// CLR meta-data size  : 2932               (57.27%)
// CLR additional info : 128                ( 2.50%)
// CLR method headers  : 13                 ( 0.25%)
// Managed code         : 625               (12.21%)
// Data                 : 512               (10.00%)
// Unaccounted          : 155               ( 3.03%)

// Num.of PE sections   : 2
//   .text    - 4096
//   .reloc   - 512

// CLR meta-data size  : 2932
//   Module        -    1 (10 bytes)
//   TypeDef       -    2 (28 bytes)      0 interfaces, 0 explicit layout
//   TypeRef       -   22 (132 bytes)
//   MethodDef     -    2 (28 bytes)      0 abstract, 0 native, 2 bodies
//   MemberRef     -   40 (240 bytes)
//   StandAloneSig -    1 (2 bytes)
//   TypeSpec      -    1 (2 bytes)
//   Assembly      -    1 (22 bytes)
//   AssemblyRef   -    6 (120 bytes)
//   Strings       -   820 bytes
//   Blobs         -   852 bytes
//   UserStrings   -   488 bytes
//   Guids         -    16 bytes
//   Uncategorized -   172 bytes

// CLR additional info : 128

// CLR method headers : 13
//   Num.of method bodies  - 2
//   Num.of fat headers    - 1
//   Num.of tiny headers   - 1

// Managed code : 625
//   Ave method size - 312
// Classes defined in this module:
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// Class AtLangProgram                  (public) (auto) (ansi) 
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

// ================================= M E T A I N F O ================================================

// ===========================================================
// Metadata section: 0x424a5342, version: 1.1, extra: 0, version len: 12, version: v4.0.30319
//            flags: 0x00, streams: 5
// Stream 0: name: #~, size 648
// Stream 1: name: #Strings, size 820
// Stream 2: name: #US, size 488
// Stream 3: name: #GUID, size 16
// Stream 4: name: #Blob, size 852
// Metadata header: 2.0, heaps: 0x00, rid: 0x01, valid: 0x0000000908020447, sorted: 0x000016003301fa00
// 
// Strings: 820(0x334), Blobs: 852(0x354), Guids: 16(0x10), User strings: 488(0x1e8)
// =================================================
//  0(0): Module               cRecs:    1(0x1), cbRec: 10(0xa), cbTable:    10(0xa)
//   col  0:  Generation   oCol: 0, cbCol:2, USHORT 
//   col  1:  Name         oCol: 2, cbCol:2, string 
//   col  2:  Mvid         oCol: 4, cbCol:2, GUID   
//   col  3:  EncId        oCol: 6, cbCol:2, GUID   
//   col  4:  EncBaseId    oCol: 8, cbCol:2, GUID   
// -------------------------------------------------
//    1 == 0:0000, 1:string#b3, 2:guid#1, 3:guid#0, 4:guid#0
// =================================================
//  1(0x1): TypeRef              cRecs:   22(0x16), cbRec:  6(0x6), cbTable:   132(0x84)
//   col  0:  ResolutionScope oCol: 0, cbCol:2, ResolutionScope
//   col  1:  Name         oCol: 2, cbCol:2, string 
//   col  2:  Namespace    oCol: 4, cbCol:2, string 
// -------------------------------------------------
//    1 == 0:ResolutionScope[23000001], 1:string#1, 2:string#55
//    2 == 0:ResolutionScope[23000001], 1:string#133, 2:string#1b6
//    3 == 0:ResolutionScope[23000001], 1:string#14f, 2:string#34
//    4 == 0:ResolutionScope[23000002], 1:string#244, 2:string#2cc
//    5 == 0:ResolutionScope[23000002], 1:string#1e6, 2:string#2cc
//    6 == 0:ResolutionScope[23000003], 1:string#ab, 2:string#1b6
//    7 == 0:ResolutionScope[23000001], 1:string#251, 2:string#34
//    8 == 0:ResolutionScope[23000002], 1:string#315, 2:string#2cc
//    9 == 0:ResolutionScope[23000002], 1:string#2ed, 2:string#2cc
//    a == 0:ResolutionScope[23000002], 1:string#ff, 2:string#2cc
//    b == 0:ResolutionScope[23000004], 1:string#1d2, 2:string#2cc
//    c == 0:ResolutionScope[23000005], 1:string#16e, 2:string#1b6
//    d == 0:ResolutionScope[23000001], 1:string#213, 2:string#1b6
//    e == 0:ResolutionScope[23000001], 1:string#9f, 2:string#34
//    f == 0:ResolutionScope[23000001], 1:string#128, 2:string#309
//   10 == 0:ResolutionScope[23000001], 1:string#18f, 2:string#34
//   11 == 0:ResolutionScope[23000001], 1:string#20a, 2:string#34
//   12 == 0:ResolutionScope[23000006], 1:string#218, 2:string#269
//   13 == 0:ResolutionScope[23000001], 1:string#17a, 2:string#34
//   14 == 0:ResolutionScope[23000001], 1:string#96, 2:string#34
//   15 == 0:ResolutionScope[23000001], 1:string#2ac, 2:string#34
//   16 == 0:ResolutionScope[23000001], 1:string#2c5, 2:string#1b6
// =================================================
//  2(0x2): TypeDef              cRecs:    2(0x2), cbRec: 14(0xe), cbTable:    28(0x1c)
//   col  0:  Flags        oCol: 0, cbCol:4, ULONG  
//   col  1:  Name         oCol: 4, cbCol:2, string 
//   col  2:  Namespace    oCol: 6, cbCol:2, string 
//   col  3:  Extends      oCol: 8, cbCol:2, TypeDefOrRef
//   col  4:  FieldList    oCol: a, cbCol:2, Field  
//   col  5:  MethodList   oCol: c, cbCol:2, Method 
// -------------------------------------------------
//    1 == 0:00000000, 1:string#2b, 2:string#0, 3:TypeDefOrRef[02000000], 4:Field[4000001], 5:Method[6000001]
//    2 == 0:00000001, 1:string#196, 2:string#0, 3:TypeDefOrRef[01000016], 4:Field[4000001], 5:Method[6000001]
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
//    1 == 0:00002050, 1:0000, 2:0096, 3:string#1c2, 4:blob#34f, 5:Param[8000001]
//    2 == 0:000022c6, 1:0000, 2:1806, 3:string#263, 4:blob#aa, 5:Param[8000001]
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
// 10(0xa): MemberRef            cRecs:   40(0x28), cbRec:  6(0x6), cbTable:   240(0xf0)
//   col  0:  Class        oCol: 0, cbCol:2, MemberRefParent
//   col  1:  Name         oCol: 2, cbCol:2, string 
//   col  2:  Signature    oCol: 4, cbCol:2, blob   
// -------------------------------------------------
//    1 == 0:MemberRefParent[1b000001], 1:string#263, 2:blob#aa
//    2 == 0:MemberRefParent[1b000001], 1:string#1ad, 2:blob#ae
//    3 == 0:MemberRefParent[1b000001], 1:string#1a4, 2:blob#b6
//    4 == 0:MemberRefParent[01000003], 1:string#148, 2:blob#bd
//    5 == 0:MemberRefParent[01000004], 1:string#263, 2:blob#aa
//    6 == 0:MemberRefParent[01000002], 1:string#2be, 2:blob#164
//    7 == 0:MemberRefParent[01000004], 1:string#293, 2:blob#16a
//    8 == 0:MemberRefParent[01000005], 1:string#70, 2:blob#16f
//    9 == 0:MemberRefParent[01000004], 1:string#2db, 2:blob#aa
//    a == 0:MemberRefParent[01000006], 1:string#301, 2:blob#216
//    b == 0:MemberRefParent[01000007], 1:string#be, 2:blob#16f
//    c == 0:MemberRefParent[01000004], 1:string#329, 2:blob#21b
//    d == 0:MemberRefParent[01000008], 1:string#2e1, 2:blob#220
//    e == 0:MemberRefParent[01000008], 1:string#f2, 2:blob#225
//    f == 0:MemberRefParent[0100000a], 1:string#2a0, 2:blob#22a
//   10 == 0:MemberRefParent[0100000b], 1:string#2d7, 2:blob#22f
//   11 == 0:MemberRefParent[01000009], 1:string#172, 2:blob#235
//   12 == 0:MemberRefParent[0100000c], 1:string#13a, 2:blob#23a
//   13 == 0:MemberRefParent[0100000c], 1:string#131, 2:blob#23a
//   14 == 0:MemberRefParent[01000002], 1:string#1bd, 2:blob#23e
//   15 == 0:MemberRefParent[01000002], 1:string#74, 2:blob#244
//   16 == 0:MemberRefParent[01000003], 1:string#c8, 2:blob#164
//   17 == 0:MemberRefParent[0100000e], 1:string#2b7, 2:blob#244
//   18 == 0:MemberRefParent[0100000a], 1:string#87, 2:blob#249
//   19 == 0:MemberRefParent[0100000a], 1:string#d0, 2:blob#16f
//   1a == 0:MemberRefParent[0100000f], 1:string#22, 2:blob#24e
//   1b == 0:MemberRefParent[0100000f], 1:string#28a, 2:blob#253
//   1c == 0:MemberRefParent[0100000a], 1:string#185, 2:blob#259
//   1d == 0:MemberRefParent[01000010], 1:string#122, 2:blob#25e
//   1e == 0:MemberRefParent[01000010], 1:string#114, 2:blob#aa
//   1f == 0:MemberRefParent[01000011], 1:string#263, 2:blob#16f
//   20 == 0:MemberRefParent[01000011], 1:string#154, 2:blob#266
//   21 == 0:MemberRefParent[0100000a], 1:string#e, 2:blob#26a
//   22 == 0:MemberRefParent[01000012], 1:string#263, 2:blob#aa
//   23 == 0:MemberRefParent[01000012], 1:string#e0, 2:blob#311
//   24 == 0:MemberRefParent[01000002], 1:string#2be, 2:blob#318
//   25 == 0:MemberRefParent[01000013], 1:string#263, 2:blob#31e
//   26 == 0:MemberRefParent[01000010], 1:string#203, 2:blob#327
//   27 == 0:MemberRefParent[01000010], 1:string#11a, 2:blob#aa
//   28 == 0:MemberRefParent[01000016], 1:string#263, 2:blob#aa
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
//    1 == 0:blob#32d
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
//    1 == 0:00000000, 1:0000, 2:0000, 3:0000, 4:0000, 5:00000000, 6:blob#0, 7:string#25c, 8:string#0
// =================================================
// 33(0x21): AssemblyProcessor    cRecs:    0(0), cbRec:  4(0x4), cbTable:     0(0)
//   col  0:  Processor    oCol: 0, cbCol:4, ULONG  
// =================================================
// 34(0x22): AssemblyOS           cRecs:    0(0), cbRec: 12(0xc), cbTable:     0(0)
//   col  0:  OSPlatformId oCol: 0, cbCol:4, ULONG  
//   col  1:  OSMajorVersion oCol: 4, cbCol:4, ULONG  
//   col  2:  OSMinorVersion oCol: 8, cbCol:4, ULONG  
// =================================================
// 35(0x23): AssemblyRef          cRecs:    6(0x6), cbRec: 20(0x14), cbTable:   120(0x78)
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
//    1 == 0:0009, 1:0000, 2:0000, 3:0000, 4:00000001, 5:blob#1, 6:string#3e, 7:string#0, 8:blob#0
//    2 == 0:0009, 1:0000, 2:0000, 3:0000, 4:00000001, 5:blob#c2, 6:string#239, 7:string#0, 8:blob#0
//    3 == 0:0009, 1:0000, 2:0000, 3:0000, 4:00000001, 5:blob#174, 6:string#a4, 7:string#0, 8:blob#0
//    4 == 0:0009, 1:0000, 2:0000, 3:0000, 4:00000001, 5:blob#174, 6:string#1c7, 7:string#0, 8:blob#0
//    5 == 0:0009, 1:0000, 2:0000, 3:0000, 4:00000001, 5:blob#174, 6:string#15f, 7:string#0, 8:blob#0
//    6 == 0:0002, 1:0003, 2:0000, 3:0000, 4:00000001, 5:blob#26f, 6:string#269, 7:string#0, 8:blob#0
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
.assembly extern /*23000002*/ System.Net.HttpListener
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
.assembly extern /*23000003*/ System.Console
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
.assembly extern /*23000004*/ System.Net.WebHeaderCollection
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
.assembly extern /*23000005*/ System.Private.Uri
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
.assembly extern /*23000006*/ Microsoft.AspNetCore.StaticFiles
{
  .publickey = (00 24 00 00 04 80 00 00 94 00 00 00 06 02 00 00   // .$..............
                00 24 00 00 52 53 41 31 00 04 00 00 01 00 01 00   // .$..RSA1........
                F3 3A 29 04 4F A9 D7 40 C9 B3 21 3A 93 E5 7C 84   // .:).O..@..!:..|.
                B4 72 C8 4E 0B 8A 0E 1A E4 8E 67 A9 F8 F6 DE 9D   // .r.N......g.....
                5F 7F 3D 52 AC 23 E4 8A C5 18 01 F1 DC 95 0A BE   // _.=R.#..........
                90 1D A3 4D 2A 9E 3B AA DB 14 1A 17 C7 7E F3 C5   // ...M*.;......~..
                65 DD 5E E5 05 4B 91 CF 63 BB 3C 6A B8 3F 72 AB   // e.^..K..c.<j.?r.
                3A AF E9 3D 0F C3 C2 34 8B 76 4F AF B0 B1 C0 73   // :..=...4.vO....s
                3D E5 14 59 AE AB 46 58 03 84 BF 9D 74 C4 E2 81   // =..Y..FX....t...
                64 B7 CD E2 47 F8 91 BA 07 89 1C 9D 87 2A D2 BB ) // d...G........*..
  .ver 2:3:0:0
}
.assembly /*20000001*/ server
{
  .ver 0:0:0:0
}
.module MainModule
// MVID: {9abc6ad2-9ca7-49ea-b577-052ac6ebf576}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00000225CE980000


// =============== CLASS MEMBERS DECLARATION ===================

.class /*02000002*/ public auto ansi AtLangProgram
       extends [System.Private.CoreLib/*23000001*/]System.Object/*01000016*/
{
  .method /*06000001*/ public hidebysig static 
          int32  Main() cil managed
  // SIG: 00 00 08
  {
    .entrypoint
    // Method begins at RVA 0x2050
    // Code size       618 (0x26a)
    .maxstack  5
    .locals /*11000001*/ init (class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object> V_0,
             string V_1,
             string V_2,
             string V_3,
             class [System.Net.HttpListener/*23000002*/]System.Net.HttpListener/*01000004*/ V_4,
             class [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerContext/*01000008*/ V_5,
             class [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerRequest/*01000009*/ V_6,
             string V_7,
             string V_8,
             string V_9,
             class [Microsoft.AspNetCore.StaticFiles/*23000006*/]Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider/*01000012*/ V_10,
             string V_11,
             int64 V_12,
             string V_13,
             uint8[] V_14,
             class [System.Private.CoreLib/*23000001*/]System.IO.Stream/*01000010*/ V_15,
             class [System.Private.CoreLib/*23000001*/]System.IO.Stream/*01000010*/ V_16,
             uint8[] V_17)
    IL_0000:  /* 73   | (0A)000001       */ newobj     instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::.ctor() /* 0A000001 */
    IL_0005:  /* 0A   |                  */ stloc.0
    IL_0006:  /* 06   |                  */ ldloc.0
    IL_0007:  /* 72   | (70)000001       */ ldstr      "SERVER_ROOT_PATH" /* 70000001 */
    IL_000c:  /* 72   | (70)000023       */ ldstr      "./samples/server_files" /* 70000023 */
    IL_0011:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_0016:  /* 6F   | (0A)000002       */ callvirt   instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::set_Item(!0,
                                                                                                                                                                                                        !1) /* 0A000002 */
    IL_001b:  /* 06   |                  */ ldloc.0
    IL_001c:  /* 72   | (70)000051       */ ldstr      "SERVER_PORT" /* 70000051 */
    IL_0021:  /* 72   | (70)000069       */ ldstr      "8081" /* 70000069 */
    IL_0026:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_002b:  /* 6F   | (0A)000002       */ callvirt   instance void class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::set_Item(!0,
                                                                                                                                                                                                        !1) /* 0A000002 */
    IL_0030:  /* 06   |                  */ ldloc.0
    IL_0031:  /* 72   | (70)000001       */ ldstr      "SERVER_ROOT_PATH" /* 70000001 */
    IL_0036:  /* 6F   | (0A)000003       */ callvirt   instance !1 class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::get_Item(!0) /* 0A000003 */
    IL_003b:  /* 75   | (01)000002       */ isinst     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_0040:  /* 28   | (0A)000004       */ call       string [System.Private.CoreLib/*23000001*/]System.IO.Path/*01000003*/::GetFullPath(string) /* 0A000004 */
    IL_0045:  /* 0B   |                  */ stloc.1
    IL_0046:  /* 06   |                  */ ldloc.0
    IL_0047:  /* 72   | (70)000051       */ ldstr      "SERVER_PORT" /* 70000051 */
    IL_004c:  /* 6F   | (0A)000003       */ callvirt   instance !1 class [System.Private.CoreLib/*23000001*/]System.Collections.Generic.Dictionary`2/*01000001*/<string,object>/*1B000001*/::get_Item(!0) /* 0A000003 */
    IL_0051:  /* 0C   |                  */ stloc.2
    IL_0052:  /* 73   | (0A)000005       */ newobj     instance void [System.Net.HttpListener/*23000002*/]System.Net.HttpListener/*01000004*/::.ctor() /* 0A000005 */
    IL_0057:  /* 13   | 04               */ stloc.s    V_4
    IL_0059:  /* 72   | (70)000073       */ ldstr      "http://+:" /* 70000073 */
    IL_005e:  /* 08   |                  */ ldloc.2
    IL_005f:  /* 28   | (0A)000006       */ call       string [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::Concat(string,
                                                                                                                                    string) /* 0A000006 */
    IL_0064:  /* 72   | (70)000087       */ ldstr      "/" /* 70000087 */
    IL_0069:  /* 28   | (0A)000006       */ call       string [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::Concat(string,
                                                                                                                                    string) /* 0A000006 */
    IL_006e:  /* 0D   |                  */ stloc.3
    IL_006f:  /* 11   | 04               */ ldloc.s    V_4
    IL_0071:  /* 6F   | (0A)000007       */ callvirt   instance class [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerPrefixCollection/*01000005*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListener/*01000004*/::get_Prefixes() /* 0A000007 */
    IL_0076:  /* 09   |                  */ ldloc.3
    IL_0077:  /* 6F   | (0A)000008       */ callvirt   instance void [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerPrefixCollection/*01000005*/::Add(string) /* 0A000008 */
    IL_007c:  /* 11   | 04               */ ldloc.s    V_4
    IL_007e:  /* 6F   | (0A)000009       */ callvirt   instance void [System.Net.HttpListener/*23000002*/]System.Net.HttpListener/*01000004*/::Start() /* 0A000009 */
    IL_0083:  /* 28   | (0A)00000A       */ call       class [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/ [System.Console/*23000003*/]System.Console/*01000006*/::get_Out() /* 0A00000A */
    IL_0088:  /* 72   | (70)00008B       */ ldstr      "Server listening at " /* 7000008B */
    IL_008d:  /* 09   |                  */ ldloc.3
    IL_008e:  /* 28   | (0A)000006       */ call       string [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::Concat(string,
                                                                                                                                    string) /* 0A000006 */
    IL_0093:  /* 6F   | (0A)00000B       */ callvirt   instance void [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/::WriteLine(string) /* 0A00000B */
    IL_0098:  /* 11   | 04               */ ldloc.s    V_4
    IL_009a:  /* 6F   | (0A)00000C       */ callvirt   instance class [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerContext/*01000008*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListener/*01000004*/::GetContext() /* 0A00000C */
    IL_009f:  /* 13   | 05               */ stloc.s    V_5
    IL_00a1:  /* 11   | 05               */ ldloc.s    V_5
    IL_00a3:  /* 6F   | (0A)00000D       */ callvirt   instance class [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerRequest/*01000009*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerContext/*01000008*/::get_Request() /* 0A00000D */
    IL_00a8:  /* 13   | 06               */ stloc.s    V_6
    IL_00aa:  /* 11   | 05               */ ldloc.s    V_5
    IL_00ac:  /* 6F   | (0A)00000E       */ callvirt   instance class [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerContext/*01000008*/::get_Response() /* 0A00000E */
    IL_00b1:  /* 6F   | (0A)00000F       */ callvirt   instance class [System.Net.WebHeaderCollection/*23000004*/]System.Net.WebHeaderCollection/*0100000B*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/::get_Headers() /* 0A00000F */
    IL_00b6:  /* 72   | (70)0000B5       */ ldstr      "X-Powered-By" /* 700000B5 */
    IL_00bb:  /* 72   | (70)0000CF       */ ldstr      "AtLang/0.0.1" /* 700000CF */
    IL_00c0:  /* 6F   | (0A)000010       */ callvirt   instance void [System.Net.WebHeaderCollection/*23000004*/]System.Net.WebHeaderCollection/*0100000B*/::Set(string,
                                                                                                                                                                 string) /* 0A000010 */
    IL_00c5:  /* 11   | 06               */ ldloc.s    V_6
    IL_00c7:  /* 6F   | (0A)000011       */ callvirt   instance class [System.Private.Uri/*23000005*/]System.Uri/*0100000C*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerRequest/*01000009*/::get_Url() /* 0A000011 */
    IL_00cc:  /* 25   |                  */ dup
    IL_00cd:  /* 6F   | (0A)000012       */ callvirt   instance string [System.Private.Uri/*23000005*/]System.Uri/*0100000C*/::get_LocalPath() /* 0A000012 */
    IL_00d2:  /* 13   | 07               */ stloc.s    V_7
    IL_00d4:  /* 6F   | (0A)000013       */ callvirt   instance string [System.Private.Uri/*23000005*/]System.Uri/*0100000C*/::ToString() /* 0A000013 */
    IL_00d9:  /* 13   | 08               */ stloc.s    V_8
    IL_00db:  /* 28   | (0A)00000A       */ call       class [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/ [System.Console/*23000003*/]System.Console/*01000006*/::get_Out() /* 0A00000A */
    IL_00e0:  /* 72   | (70)0000E9       */ ldstr      "Received request: " /* 700000E9 */
    IL_00e5:  /* 11   | 08               */ ldloc.s    V_8
    IL_00e7:  /* 28   | (0A)000006       */ call       string [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::Concat(string,
                                                                                                                                    string) /* 0A000006 */
    IL_00ec:  /* 6F   | (0A)00000B       */ callvirt   instance void [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/::WriteLine(string) /* 0A00000B */
    IL_00f1:  /* 11   | 07               */ ldloc.s    V_7
    IL_00f3:  /* 19   |                  */ ldc.i4.3
    IL_00f4:  /* 8D   | (01)00000D       */ newarr     [System.Private.CoreLib/*23000001*/]System.Char/*0100000D*/
    IL_00f9:  /* 25   |                  */ dup
    IL_00fa:  /* 16   |                  */ ldc.i4.0
    IL_00fb:  /* 1F   | 2F               */ ldc.i4.s   47
    IL_00fd:  /* 9D   |                  */ stelem.i2
    IL_00fe:  /* 25   |                  */ dup
    IL_00ff:  /* 17   |                  */ ldc.i4.1
    IL_0100:  /* 1F   | 2E               */ ldc.i4.s   46
    IL_0102:  /* 9D   |                  */ stelem.i2
    IL_0103:  /* 25   |                  */ dup
    IL_0104:  /* 18   |                  */ ldc.i4.2
    IL_0105:  /* 1F   | 5C               */ ldc.i4.s   92
    IL_0107:  /* 9D   |                  */ stelem.i2
    IL_0108:  /* 28   | (0A)000014       */ call       instance string [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::Trim(char[]) /* 0A000014 */
    IL_010d:  /* 13   | 09               */ stloc.s    V_9
    IL_010f:  /* 11   | 09               */ ldloc.s    V_9
    IL_0111:  /* 28   | (0A)000015       */ call       bool [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::IsNullOrWhiteSpace(string) /* 0A000015 */
    IL_0116:  /* 2C   | 07               */ brfalse.s  IL_011f

    IL_0118:  /* 72   | (70)00010F       */ ldstr      "index.html" /* 7000010F */
    IL_011d:  /* 13   | 09               */ stloc.s    V_9
    IL_011f:  /* 07   |                  */ ldloc.1
    IL_0120:  /* 11   | 09               */ ldloc.s    V_9
    IL_0122:  /* 28   | (0A)000016       */ call       string [System.Private.CoreLib/*23000001*/]System.IO.Path/*01000003*/::Combine(string,
                                                                                                                                      string) /* 0A000016 */
    IL_0127:  /* 13   | 0D               */ stloc.s    V_13
    IL_0129:  /* 28   | (0A)00000A       */ call       class [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/ [System.Console/*23000003*/]System.Console/*01000006*/::get_Out() /* 0A00000A */
    IL_012e:  /* 11   | 0D               */ ldloc.s    V_13
    IL_0130:  /* 6F   | (0A)00000B       */ callvirt   instance void [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/::WriteLine(string) /* 0A00000B */
    IL_0135:  /* 11   | 0D               */ ldloc.s    V_13
    IL_0137:  /* 28   | (0A)000017       */ call       bool [System.Private.CoreLib/*23000001*/]System.IO.File/*0100000E*/::Exists(string) /* 0A000017 */
    IL_013c:  /* 3A   | 0000006A         */ brtrue     IL_01ab

    IL_0141:  /* 28   | (0A)00000A       */ call       class [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/ [System.Console/*23000003*/]System.Console/*01000006*/::get_Out() /* 0A00000A */
    IL_0146:  /* 72   | (70)000125       */ ldstr      "Not found" /* 70000125 */
    IL_014b:  /* 6F   | (0A)00000B       */ callvirt   instance void [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/::WriteLine(string) /* 0A00000B */
    IL_0150:  /* 11   | 05               */ ldloc.s    V_5
    IL_0152:  /* 6F   | (0A)00000E       */ callvirt   instance class [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerContext/*01000008*/::get_Response() /* 0A00000E */
    IL_0157:  /* 20   | 00000194         */ ldc.i4     0x194
    IL_015c:  /* 6F   | (0A)000018       */ callvirt   instance void [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/::set_StatusCode(int32) /* 0A000018 */
    IL_0161:  /* 11   | 05               */ ldloc.s    V_5
    IL_0163:  /* 6F   | (0A)00000E       */ callvirt   instance class [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerContext/*01000008*/::get_Response() /* 0A00000E */
    IL_0168:  /* 72   | (70)000139       */ ldstr      "text/plain" /* 70000139 */
    IL_016d:  /* 6F   | (0A)000019       */ callvirt   instance void [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/::set_ContentType(string) /* 0A000019 */
    IL_0172:  /* 28   | (0A)00001A       */ call       class [System.Private.CoreLib/*23000001*/]System.Text.Encoding/*0100000F*/ [System.Private.CoreLib/*23000001*/]System.Text.Encoding/*0100000F*/::get_UTF8() /* 0A00001A */
    IL_0177:  /* 72   | (70)00014F       */ ldstr      "404 Not Found" /* 7000014F */
    IL_017c:  /* 6F   | (0A)00001B       */ callvirt   instance uint8[] [System.Private.CoreLib/*23000001*/]System.Text.Encoding/*0100000F*/::GetBytes(string) /* 0A00001B */
    IL_0181:  /* 13   | 11               */ stloc.s    V_17
    IL_0183:  /* 11   | 05               */ ldloc.s    V_5
    IL_0185:  /* 6F   | (0A)00000E       */ callvirt   instance class [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerContext/*01000008*/::get_Response() /* 0A00000E */
    IL_018a:  /* 6F   | (0A)00001C       */ callvirt   instance class [System.Private.CoreLib/*23000001*/]System.IO.Stream/*01000010*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/::get_OutputStream() /* 0A00001C */
    IL_018f:  /* 13   | 10               */ stloc.s    V_16
    IL_0191:  /* 11   | 10               */ ldloc.s    V_16
    IL_0193:  /* 11   | 11               */ ldloc.s    V_17
    IL_0195:  /* 16   |                  */ ldc.i4.0
    IL_0196:  /* 11   | 11               */ ldloc.s    V_17
    IL_0198:  /* 8E   |                  */ ldlen
    IL_0199:  /* 69   |                  */ conv.i4
    IL_019a:  /* 6F   | (0A)00001D       */ callvirt   instance void [System.Private.CoreLib/*23000001*/]System.IO.Stream/*01000010*/::Write(uint8[],
                                                                                                                                             int32,
                                                                                                                                             int32) /* 0A00001D */
    IL_019f:  /* 11   | 10               */ ldloc.s    V_16
    IL_01a1:  /* 6F   | (0A)00001E       */ callvirt   instance void [System.Private.CoreLib/*23000001*/]System.IO.Stream/*01000010*/::Close() /* 0A00001E */
    IL_01a6:  /* 38   | 000000B8         */ br         IL_0263

    IL_01ab:  /* 28   | (0A)00000A       */ call       class [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/ [System.Console/*23000003*/]System.Console/*01000006*/::get_Out() /* 0A00000A */
    IL_01b0:  /* 72   | (70)00016B       */ ldstr      "Found" /* 7000016B */
    IL_01b5:  /* 6F   | (0A)00000B       */ callvirt   instance void [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/::WriteLine(string) /* 0A00000B */
    IL_01ba:  /* 11   | 0D               */ ldloc.s    V_13
    IL_01bc:  /* 73   | (0A)00001F       */ newobj     instance void [System.Private.CoreLib/*23000001*/]System.IO.FileInfo/*01000011*/::.ctor(string) /* 0A00001F */
    IL_01c1:  /* 6F   | (0A)000020       */ callvirt   instance int64 [System.Private.CoreLib/*23000001*/]System.IO.FileInfo/*01000011*/::get_Length() /* 0A000020 */
    IL_01c6:  /* 13   | 0C               */ stloc.s    V_12
    IL_01c8:  /* 11   | 05               */ ldloc.s    V_5
    IL_01ca:  /* 6F   | (0A)00000E       */ callvirt   instance class [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerContext/*01000008*/::get_Response() /* 0A00000E */
    IL_01cf:  /* 11   | 0C               */ ldloc.s    V_12
    IL_01d1:  /* 6F   | (0A)000021       */ callvirt   instance void [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/::set_ContentLength64(int64) /* 0A000021 */
    IL_01d6:  /* 73   | (0A)000022       */ newobj     instance void [Microsoft.AspNetCore.StaticFiles/*23000006*/]Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider/*01000012*/::.ctor() /* 0A000022 */
    IL_01db:  /* 13   | 0A               */ stloc.s    V_10
    IL_01dd:  /* 72   | (70)000177       */ ldstr      "text/html" /* 70000177 */
    IL_01e2:  /* 13   | 0B               */ stloc.s    V_11
    IL_01e4:  /* 11   | 0A               */ ldloc.s    V_10
    IL_01e6:  /* 11   | 0D               */ ldloc.s    V_13
    IL_01e8:  /* 12   | 0B               */ ldloca.s   V_11
    IL_01ea:  /* 6F   | (0A)000023       */ callvirt   instance bool [Microsoft.AspNetCore.StaticFiles/*23000006*/]Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider/*01000012*/::TryGetContentType(string,
                                                                                                                                                                                                                    string&) /* 0A000023 */
    IL_01ef:  /* 2D   | 07               */ brtrue.s   IL_01f8

    IL_01f1:  /* 72   | (70)00018B       */ ldstr      "application/octet-stream" /* 7000018B */
    IL_01f6:  /* 13   | 0B               */ stloc.s    V_11
    IL_01f8:  /* 28   | (0A)00000A       */ call       class [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/ [System.Console/*23000003*/]System.Console/*01000006*/::get_Out() /* 0A00000A */
    IL_01fd:  /* 1B   |                  */ ldc.i4.5
    IL_01fe:  /* 8D   | (01)000002       */ newarr     [System.Private.CoreLib/*23000001*/]System.String/*01000002*/
    IL_0203:  /* 25   |                  */ dup
    IL_0204:  /* 16   |                  */ ldc.i4.0
    IL_0205:  /* 11   | 0D               */ ldloc.s    V_13
    IL_0207:  /* A2   |                  */ stelem.ref
    IL_0208:  /* 25   |                  */ dup
    IL_0209:  /* 17   |                  */ ldc.i4.1
    IL_020a:  /* 72   | (70)0001BD       */ ldstr      " > Type: " /* 700001BD */
    IL_020f:  /* A2   |                  */ stelem.ref
    IL_0210:  /* 25   |                  */ dup
    IL_0211:  /* 18   |                  */ ldc.i4.2
    IL_0212:  /* 11   | 0B               */ ldloc.s    V_11
    IL_0214:  /* A2   |                  */ stelem.ref
    IL_0215:  /* 25   |                  */ dup
    IL_0216:  /* 19   |                  */ ldc.i4.3
    IL_0217:  /* 72   | (70)0001D1       */ ldstr      " > Bytes: " /* 700001D1 */
    IL_021c:  /* A2   |                  */ stelem.ref
    IL_021d:  /* 25   |                  */ dup
    IL_021e:  /* 1A   |                  */ ldc.i4.4
    IL_021f:  /* 11   | 0B               */ ldloc.s    V_11
    IL_0221:  /* A2   |                  */ stelem.ref
    IL_0222:  /* 28   | (0A)000024       */ call       string [System.Private.CoreLib/*23000001*/]System.String/*01000002*/::Concat(string[]) /* 0A000024 */
    IL_0227:  /* 6F   | (0A)00000B       */ callvirt   instance void [System.Private.CoreLib/*23000001*/]System.IO.TextWriter/*01000007*/::WriteLine(string) /* 0A00000B */
    IL_022c:  /* 11   | 05               */ ldloc.s    V_5
    IL_022e:  /* 6F   | (0A)00000E       */ callvirt   instance class [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerContext/*01000008*/::get_Response() /* 0A00000E */
    IL_0233:  /* 11   | 0B               */ ldloc.s    V_11
    IL_0235:  /* 6F   | (0A)000019       */ callvirt   instance void [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/::set_ContentType(string) /* 0A000019 */
    IL_023a:  /* 11   | 0D               */ ldloc.s    V_13
    IL_023c:  /* 19   |                  */ ldc.i4.3
    IL_023d:  /* 17   |                  */ ldc.i4.1
    IL_023e:  /* 73   | (0A)000025       */ newobj     instance void [System.Private.CoreLib/*23000001*/]System.IO.FileStream/*01000013*/::.ctor(string,
                                                                                                                                                 valuetype [System.Private.CoreLib/*23000001*/]System.IO.FileMode/*01000014*/,
                                                                                                                                                 valuetype [System.Private.CoreLib/*23000001*/]System.IO.FileAccess/*01000015*/) /* 0A000025 */
    IL_0243:  /* 13   | 0F               */ stloc.s    V_15
    IL_0245:  /* 11   | 05               */ ldloc.s    V_5
    IL_0247:  /* 6F   | (0A)00000E       */ callvirt   instance class [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerContext/*01000008*/::get_Response() /* 0A00000E */
    IL_024c:  /* 6F   | (0A)00001C       */ callvirt   instance class [System.Private.CoreLib/*23000001*/]System.IO.Stream/*01000010*/ [System.Net.HttpListener/*23000002*/]System.Net.HttpListenerResponse/*0100000A*/::get_OutputStream() /* 0A00001C */
    IL_0251:  /* 13   | 10               */ stloc.s    V_16
    IL_0253:  /* 11   | 0F               */ ldloc.s    V_15
    IL_0255:  /* 11   | 10               */ ldloc.s    V_16
    IL_0257:  /* 6F   | (0A)000026       */ callvirt   instance void [System.Private.CoreLib/*23000001*/]System.IO.Stream/*01000010*/::CopyTo(class [System.Private.CoreLib/*23000001*/]System.IO.Stream/*01000010*/) /* 0A000026 */
    IL_025c:  /* 11   | 0F               */ ldloc.s    V_15
    IL_025e:  /* 6F   | (0A)000027       */ callvirt   instance void [System.Private.CoreLib/*23000001*/]System.IO.Stream/*01000010*/::Dispose() /* 0A000027 */
    IL_0263:  /* 38   | FFFFFE30         */ br         IL_0098

    IL_0268:  /* 16   |                  */ ldc.i4.0
    IL_0269:  /* 2A   |                  */ ret
  } // end of method AtLangProgram::Main

  .method /*06000002*/ public specialname rtspecialname 
          instance void  .ctor() cil managed
  // SIG: 20 00 01
  {
    // Method begins at RVA 0x22c6
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  /* 02   |                  */ ldarg.0
    IL_0001:  /* 28   | (0A)000028       */ call       instance void [System.Private.CoreLib/*23000001*/]System.Object/*01000016*/::.ctor() /* 0A000028 */
    IL_0006:  /* 2A   |                  */ ret
  } // end of method AtLangProgram::.ctor

} // end of class AtLangProgram


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
