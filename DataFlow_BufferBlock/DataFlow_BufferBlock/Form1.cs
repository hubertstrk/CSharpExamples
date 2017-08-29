using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace DataFlow_BufferBlock
{
    public partial class Form1 : Form
    {
        //private BufferBlock<int> _Buffer;
        private ActionBlock<string> _Logger;
        private BroadcastBlock<int> _Broadcaster;
        private TransformBlock<int, string> _Transformer1;
        private CancellationTokenSource _Cts = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
            _LblBufferSizeT1.Text = "0";

            _Timer.Tick += _Timer_Tick;
            _Timer.Enabled = true;
            _Timer.Start();

            CreateProcessingPipeline();
        }

        private void _Timer_Tick( object sender, EventArgs e )
        {
            _LblBufferSizeT1.Text = _Transformer1.InputCount.ToString();
        }

        private void CreateProcessingPipeline()
        {
            //_Buffer = new BufferBlock<int>();
            _Broadcaster = new BroadcastBlock<int>( ( int number ) => { return number; } );
            _Transformer1 = new TransformBlock<int, string>( ( int number ) =>
            {
                return Transform( number );
            } );
            _Logger = new ActionBlock<string>( ( string text ) =>
            {
                Log( text );
            } );

            //_Buffer.LinkTo( _Transformer1 );
            _Broadcaster.LinkTo( _Transformer1 );
            _Transformer1.LinkTo( _Logger );
        }

        private string Transform( int number )
        {
            Thread.Sleep( 1000 );
            return number.ToString();
        }

        private void Log( string text )
        {
            using ( StreamWriter file = new StreamWriter( @"C:\Temp\log.txt" ) )
            {
                file.WriteLine( text );
                file.Close();
            }
        }

        private void _BtnClose_Click( object sender, EventArgs e )
        {
            _Broadcaster.Complete();
            _Transformer1.Complete();
            _Logger.Complete();
            if ( _Timer != null )
            {
                _Timer.Stop();
                _Timer.Dispose();
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private async void _BtnStart_Click( object sender, EventArgs e )
        {
            _Cts = new CancellationTokenSource();
            int i = 0;
            await Task.Run( () =>
            {
                while ( true )
                {
                    Thread.Sleep( 100 );
                    if ( _Cts.IsCancellationRequested )
                        break;

                    _Broadcaster.Post<int>( i );
                    i++;
                }
            } );
        }

        private void _BtnCancel_Click( object sender, EventArgs e )
        {
            _Cts.Cancel();
        }
    }
}
