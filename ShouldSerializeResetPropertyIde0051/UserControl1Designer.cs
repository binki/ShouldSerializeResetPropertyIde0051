using System.ComponentModel.Design;
using System.Threading;
using System.Windows.Forms.Design;

namespace ShouldSerializeResetPropertyIde0051
{
    // https://stackoverflow.com/a/47599686/429091
    class UserControl1Designer : ControlDesigner
    {
        DesignerVerbCollection verbs;
        public override DesignerVerbCollection Verbs => LazyInitializer.EnsureInitialized(ref verbs, () =>
        {
            var verbs = base.Verbs;
            verbs.Add(new DesignerVerb("SetNewObject", (sender, e) =>
            {
                var userControl1 = (UserControl1)Control;
                userControl1.X = new object();
            }));
            return verbs;
        });
    }
}
