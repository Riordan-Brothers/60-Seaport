using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_TOD_LIGHTING_SCENE_CONTROLLER_V2_4
{
    public class UserModuleClass_TOD_LIGHTING_SCENE_CONTROLLER_V2_4 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.DigitalInput ALL_ON;
        Crestron.Logos.SplusObjects.DigitalInput ALL_OFF;
        Crestron.Logos.SplusObjects.DigitalInput LOADS_STABLE;
        Crestron.Logos.SplusObjects.DigitalInput INC_ALL_IN_SCENE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> INC_IN_SCENE;
        Crestron.Logos.SplusObjects.AnalogInput SCENE_RECALL_NUM;
        Crestron.Logos.SplusObjects.AnalogInput SCENE_SAVE_NUM;
        Crestron.Logos.SplusObjects.AnalogInput NUM_ZONES;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> LIGHT_LOAD;
        Crestron.Logos.SplusObjects.StringOutput MOD_MSG__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput LIGHT_PRESET_RECALL_GO;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> INC_IN_SCENE_FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> LIGHT_LOAD_PRESET;
        InOutArray<UShortParameter> SCENE_DEFAULT_LEVEL;
        StringParameter STORAGEPATH__DOLLAR__;
        StringParameter FILENAMEHEADER__DOLLAR__;
        ushort I = 0;
        ushort J = 0;
        ushort K = 0;
        ushort M = 0;
        ushort N = 0;
        ushort P = 0;
        ushort [,] LIGHT_PRESETS_IN;
        ushort [,] LIGHT_PRESETS_OUT;
        ushort [] LIGHT_RAMP_STATUS;
        short NFILEHANDLE = 0;
        short NFILEERROR = 0;
        CrestronString FILENAMEANDPATH__DOLLAR__;
        object INC_IN_SCENE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 106;
                I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 107;
                INC_IN_SCENE_FB [ I]  .Value = (ushort) ( Functions.Not( INC_IN_SCENE_FB[ I ] .Value ) ) ; 
                __context__.SourceCodeLine = 108;
                LIGHT_PRESETS_IN [ I , 2] = (ushort) ( INC_IN_SCENE_FB[ I ] .Value ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object LOADS_STABLE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 113;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)NUM_ZONES  .UshortValue; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 115;
                LIGHT_PRESETS_IN [ J , 1] = (ushort) ( LIGHT_LOAD[ J ] .UshortValue ) ; 
                __context__.SourceCodeLine = 113;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object ALL_ON_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 121;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)NUM_ZONES  .UshortValue; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( K  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (K  >= __FN_FORSTART_VAL__1) && (K  <= __FN_FOREND_VAL__1) ) : ( (K  <= __FN_FORSTART_VAL__1) && (K  >= __FN_FOREND_VAL__1) ) ; K  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 123;
            INC_IN_SCENE_FB [ K]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 124;
            LIGHT_PRESETS_IN [ K , 2] = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 125;
            LIGHT_LOAD_PRESET [ K]  .Value = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 121;
            } 
        
        __context__.SourceCodeLine = 127;
        Functions.Pulse ( 10, LIGHT_PRESET_RECALL_GO ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ALL_OFF_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 132;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)NUM_ZONES  .UshortValue; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( M  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (M  >= __FN_FORSTART_VAL__1) && (M  <= __FN_FOREND_VAL__1) ) : ( (M  <= __FN_FORSTART_VAL__1) && (M  >= __FN_FOREND_VAL__1) ) ; M  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 134;
            INC_IN_SCENE_FB [ M]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 135;
            LIGHT_PRESETS_IN [ M , 2] = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 136;
            LIGHT_LOAD_PRESET [ M]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 132;
            } 
        
        __context__.SourceCodeLine = 138;
        Functions.Pulse ( 10, LIGHT_PRESET_RECALL_GO ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SCENE_SAVE_NUM_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 146;
        MakeString ( MOD_MSG__DOLLAR__ , "Scene Save Started.\r\n") ; 
        __context__.SourceCodeLine = 147;
        FILENAMEANDPATH__DOLLAR__  .UpdateValue ( STORAGEPATH__DOLLAR__ + FILENAMEHEADER__DOLLAR__ + "-" + Functions.ItoA (  (int) ( SCENE_SAVE_NUM  .UshortValue ) ) + ".dat"  ) ; 
        __context__.SourceCodeLine = 148;
        StartFileOperations ( ) ; 
        __context__.SourceCodeLine = 149;
        NFILEHANDLE = (short) ( FileOpen( FILENAMEANDPATH__DOLLAR__ ,(ushort) (((32768 | 1) | 256) | 512) ) ) ; 
        __context__.SourceCodeLine = 150;
        MakeString ( MOD_MSG__DOLLAR__ , "File Open code {0:d}\r\n", (short)NFILEHANDLE) ; 
        __context__.SourceCodeLine = 151;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEHANDLE >= 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 153;
            NFILEERROR = (short) ( WriteIntegerArray( (short)( NFILEHANDLE ) , LIGHT_PRESETS_IN ) ) ; 
            __context__.SourceCodeLine = 155;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEERROR > 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 156;
                MakeString ( MOD_MSG__DOLLAR__ , "Array written to file correctly.\r\n") ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 158;
                MakeString ( MOD_MSG__DOLLAR__ , "Error code {0:d}\r\n", (short)NFILEERROR) ; 
                }
            
            } 
        
        __context__.SourceCodeLine = 160;
        FileClose (  (short) ( NFILEHANDLE ) ) ; 
        __context__.SourceCodeLine = 161;
        EndFileOperations ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SCENE_RECALL_NUM_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 166;
        MakeString ( MOD_MSG__DOLLAR__ , "Scene Recall Started.\r\n") ; 
        __context__.SourceCodeLine = 167;
        FILENAMEANDPATH__DOLLAR__  .UpdateValue ( STORAGEPATH__DOLLAR__ + FILENAMEHEADER__DOLLAR__ + "-" + Functions.ItoA (  (int) ( SCENE_RECALL_NUM  .UshortValue ) ) + ".dat"  ) ; 
        __context__.SourceCodeLine = 168;
        StartFileOperations ( ) ; 
        __context__.SourceCodeLine = 169;
        NFILEHANDLE = (short) ( FileOpen( FILENAMEANDPATH__DOLLAR__ ,(ushort) (32768 | 0) ) ) ; 
        __context__.SourceCodeLine = 170;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEHANDLE >= 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 172;
            NFILEERROR = (short) ( ReadIntegerArray( (short)( NFILEHANDLE ) , ref LIGHT_PRESETS_OUT ) ) ; 
            __context__.SourceCodeLine = 174;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEERROR > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 176;
                MakeString ( MOD_MSG__DOLLAR__ , "Array read from file correctly.\r\n") ; 
                __context__.SourceCodeLine = 177;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)NUM_ZONES  .UshortValue; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( N  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (N  >= __FN_FORSTART_VAL__1) && (N  <= __FN_FOREND_VAL__1) ) : ( (N  <= __FN_FORSTART_VAL__1) && (N  >= __FN_FOREND_VAL__1) ) ; N  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 179;
                    INC_IN_SCENE_FB [ N]  .Value = (ushort) ( LIGHT_PRESETS_OUT[ N , 2 ] ) ; 
                    __context__.SourceCodeLine = 180;
                    LIGHT_PRESETS_IN [ N , 2] = (ushort) ( LIGHT_PRESETS_OUT[ N , 2 ] ) ; 
                    __context__.SourceCodeLine = 182;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (INC_IN_SCENE_FB[ N ] .Value == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (INC_ALL_IN_SCENE  .Value == 1) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 184;
                        LIGHT_LOAD_PRESET [ N]  .Value = (ushort) ( LIGHT_PRESETS_OUT[ N , 1 ] ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 188;
                        LIGHT_LOAD_PRESET [ N]  .Value = (ushort) ( LIGHT_PRESETS_IN[ N , 1 ] ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 177;
                    } 
                
                __context__.SourceCodeLine = 191;
                Functions.Pulse ( 10, LIGHT_PRESET_RECALL_GO ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 195;
                /* Trace( "Error code {0:d}\r\n", (short)NFILEERROR) */ ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 201;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SCENE_DEFAULT_LEVEL[ SCENE_RECALL_NUM  .UshortValue ] .Value > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 203;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)NUM_ZONES  .UshortValue; 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( N  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (N  >= __FN_FORSTART_VAL__2) && (N  <= __FN_FOREND_VAL__2) ) : ( (N  <= __FN_FORSTART_VAL__2) && (N  >= __FN_FOREND_VAL__2) ) ; N  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 205;
                    INC_IN_SCENE_FB [ N]  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 206;
                    LIGHT_PRESETS_IN [ N , 2] = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 207;
                    LIGHT_LOAD_PRESET [ N]  .Value = (ushort) ( SCENE_DEFAULT_LEVEL[ SCENE_RECALL_NUM  .UshortValue ] .Value ) ; 
                    __context__.SourceCodeLine = 203;
                    } 
                
                __context__.SourceCodeLine = 209;
                Functions.Pulse ( 10, LIGHT_PRESET_RECALL_GO ) ; 
                } 
            
            } 
        
        __context__.SourceCodeLine = 212;
        FileClose (  (short) ( NFILEHANDLE ) ) ; 
        __context__.SourceCodeLine = 213;
        EndFileOperations ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 262;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 263;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)100; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( P  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (P  >= __FN_FORSTART_VAL__1) && (P  <= __FN_FOREND_VAL__1) ) : ( (P  <= __FN_FORSTART_VAL__1) && (P  >= __FN_FOREND_VAL__1) ) ; P  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 265;
            LIGHT_PRESETS_IN [ P , 1] = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 266;
            LIGHT_PRESETS_IN [ P , 2] = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 263;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    LIGHT_RAMP_STATUS  = new ushort[ 101 ];
    LIGHT_PRESETS_IN  = new ushort[ 101,3 ];
    LIGHT_PRESETS_OUT  = new ushort[ 101,3 ];
    FILENAMEANDPATH__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    
    ALL_ON = new Crestron.Logos.SplusObjects.DigitalInput( ALL_ON__DigitalInput__, this );
    m_DigitalInputList.Add( ALL_ON__DigitalInput__, ALL_ON );
    
    ALL_OFF = new Crestron.Logos.SplusObjects.DigitalInput( ALL_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( ALL_OFF__DigitalInput__, ALL_OFF );
    
    LOADS_STABLE = new Crestron.Logos.SplusObjects.DigitalInput( LOADS_STABLE__DigitalInput__, this );
    m_DigitalInputList.Add( LOADS_STABLE__DigitalInput__, LOADS_STABLE );
    
    INC_ALL_IN_SCENE = new Crestron.Logos.SplusObjects.DigitalInput( INC_ALL_IN_SCENE__DigitalInput__, this );
    m_DigitalInputList.Add( INC_ALL_IN_SCENE__DigitalInput__, INC_ALL_IN_SCENE );
    
    INC_IN_SCENE = new InOutArray<DigitalInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        INC_IN_SCENE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( INC_IN_SCENE__DigitalInput__ + i, INC_IN_SCENE__DigitalInput__, this );
        m_DigitalInputList.Add( INC_IN_SCENE__DigitalInput__ + i, INC_IN_SCENE[i+1] );
    }
    
    LIGHT_PRESET_RECALL_GO = new Crestron.Logos.SplusObjects.DigitalOutput( LIGHT_PRESET_RECALL_GO__DigitalOutput__, this );
    m_DigitalOutputList.Add( LIGHT_PRESET_RECALL_GO__DigitalOutput__, LIGHT_PRESET_RECALL_GO );
    
    INC_IN_SCENE_FB = new InOutArray<DigitalOutput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        INC_IN_SCENE_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( INC_IN_SCENE_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( INC_IN_SCENE_FB__DigitalOutput__ + i, INC_IN_SCENE_FB[i+1] );
    }
    
    SCENE_RECALL_NUM = new Crestron.Logos.SplusObjects.AnalogInput( SCENE_RECALL_NUM__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SCENE_RECALL_NUM__AnalogSerialInput__, SCENE_RECALL_NUM );
    
    SCENE_SAVE_NUM = new Crestron.Logos.SplusObjects.AnalogInput( SCENE_SAVE_NUM__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SCENE_SAVE_NUM__AnalogSerialInput__, SCENE_SAVE_NUM );
    
    NUM_ZONES = new Crestron.Logos.SplusObjects.AnalogInput( NUM_ZONES__AnalogSerialInput__, this );
    m_AnalogInputList.Add( NUM_ZONES__AnalogSerialInput__, NUM_ZONES );
    
    LIGHT_LOAD = new InOutArray<AnalogInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        LIGHT_LOAD[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( LIGHT_LOAD__AnalogSerialInput__ + i, LIGHT_LOAD__AnalogSerialInput__, this );
        m_AnalogInputList.Add( LIGHT_LOAD__AnalogSerialInput__ + i, LIGHT_LOAD[i+1] );
    }
    
    LIGHT_LOAD_PRESET = new InOutArray<AnalogOutput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        LIGHT_LOAD_PRESET[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( LIGHT_LOAD_PRESET__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( LIGHT_LOAD_PRESET__AnalogSerialOutput__ + i, LIGHT_LOAD_PRESET[i+1] );
    }
    
    MOD_MSG__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( MOD_MSG__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( MOD_MSG__DOLLAR____AnalogSerialOutput__, MOD_MSG__DOLLAR__ );
    
    SCENE_DEFAULT_LEVEL = new InOutArray<UShortParameter>( 24, this );
    for( uint i = 0; i < 24; i++ )
    {
        SCENE_DEFAULT_LEVEL[i+1] = new UShortParameter( SCENE_DEFAULT_LEVEL__Parameter__ + i, SCENE_DEFAULT_LEVEL__Parameter__, this );
        m_ParameterList.Add( SCENE_DEFAULT_LEVEL__Parameter__ + i, SCENE_DEFAULT_LEVEL[i+1] );
    }
    
    STORAGEPATH__DOLLAR__ = new StringParameter( STORAGEPATH__DOLLAR____Parameter__, this );
    m_ParameterList.Add( STORAGEPATH__DOLLAR____Parameter__, STORAGEPATH__DOLLAR__ );
    
    FILENAMEHEADER__DOLLAR__ = new StringParameter( FILENAMEHEADER__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FILENAMEHEADER__DOLLAR____Parameter__, FILENAMEHEADER__DOLLAR__ );
    
    
    for( uint i = 0; i < 100; i++ )
        INC_IN_SCENE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( INC_IN_SCENE_OnPush_0, true ) );
        
    LOADS_STABLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( LOADS_STABLE_OnPush_1, true ) );
    ALL_ON.OnDigitalPush.Add( new InputChangeHandlerWrapper( ALL_ON_OnPush_2, true ) );
    ALL_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ALL_OFF_OnPush_3, true ) );
    SCENE_SAVE_NUM.OnAnalogChange.Add( new InputChangeHandlerWrapper( SCENE_SAVE_NUM_OnChange_4, true ) );
    SCENE_RECALL_NUM.OnAnalogChange.Add( new InputChangeHandlerWrapper( SCENE_RECALL_NUM_OnChange_5, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_TOD_LIGHTING_SCENE_CONTROLLER_V2_4 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint ALL_ON__DigitalInput__ = 0;
const uint ALL_OFF__DigitalInput__ = 1;
const uint LOADS_STABLE__DigitalInput__ = 2;
const uint INC_ALL_IN_SCENE__DigitalInput__ = 3;
const uint INC_IN_SCENE__DigitalInput__ = 4;
const uint SCENE_RECALL_NUM__AnalogSerialInput__ = 0;
const uint SCENE_SAVE_NUM__AnalogSerialInput__ = 1;
const uint NUM_ZONES__AnalogSerialInput__ = 2;
const uint LIGHT_LOAD__AnalogSerialInput__ = 3;
const uint MOD_MSG__DOLLAR____AnalogSerialOutput__ = 0;
const uint LIGHT_PRESET_RECALL_GO__DigitalOutput__ = 0;
const uint INC_IN_SCENE_FB__DigitalOutput__ = 1;
const uint LIGHT_LOAD_PRESET__AnalogSerialOutput__ = 1;
const uint SCENE_DEFAULT_LEVEL__Parameter__ = 10;
const uint STORAGEPATH__DOLLAR____Parameter__ = 34;
const uint FILENAMEHEADER__DOLLAR____Parameter__ = 35;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
