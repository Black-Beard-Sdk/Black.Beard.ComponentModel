// Ignore Spelling: Desactivate

namespace Bb
{


    /// <summary>
    /// This class provides debugging functionality for local development.
    /// </summary>
    public class LocalDebug
    {

        static LocalDebug()
        {
            LocalDebug.StopActivated = System.Diagnostics.Debugger.IsAttached;
        }

        /// <summary>
        /// Triggers a breakpoint if debugging is activated.
        /// </summary>
        /// <remarks>
        /// This method checks if debugging is activated and triggers a breakpoint if the debugger is attached.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// LocalDebug.Stop();
        /// </code>
        /// </example>
        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        public static void Stop()
        {
            if (LocalDebug.StopActivated)
                System.Diagnostics.Debugger.Break();
        }

        /// <summary>
        /// Deactivates the debugging stop functionality.
        /// </summary>
        /// <remarks>
        /// This method disables the ability to trigger breakpoints using the <see cref="Stop"/> method.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// LocalDebug.Desactivate();
        /// </code>
        /// </example>
        public static void Desactivate()
        {
            LocalDebug.StopActivated = false;
        }

        /// <summary>
        /// Activates the debugging stop functionality.
        /// </summary>
        /// <remarks>
        /// This method enables the ability to trigger breakpoints using the <see cref="Stop"/> method.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// LocalDebug.Activate();
        /// </code>
        /// </example>
        public static void Activate()
        {
            LocalDebug.StopActivated = true;
        }

        /// <summary>
        /// Gets a value indicating whether the debugging stop functionality is activated.
        /// </summary>
        /// <value><see langword="true"/> if debugging stop is activated; otherwise, <see langword="false"/>.</value>
        /// <remarks>
        /// This property indicates whether the <see cref="Stop"/> method will trigger a breakpoint.
        /// </remarks>
        public static bool StopActivated { get; private set; }

    }

}
