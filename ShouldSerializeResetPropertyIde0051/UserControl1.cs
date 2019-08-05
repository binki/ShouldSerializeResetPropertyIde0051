using System.ComponentModel;
using System.Windows.Forms;

namespace ShouldSerializeResetPropertyIde0051
{
    [Designer(typeof(UserControl1Designer))]
    public partial class UserControl1
        : UserControl
        , INotifyPropertyChanged
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        readonly static object defaultXValue = new object();

        public event PropertyChangedEventHandler PropertyChanged;

        object x = defaultXValue;
        public object X
        {
            get => x;
            set
            {
                x = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X)));
            }
        }
        bool ShouldSerializeX() => X != defaultXValue;
        // Incorrect “IDE0051: Private member ‘UserControl1.ResetX’ is unused.”
        void ResetX() => X = defaultXValue;
    }
}
