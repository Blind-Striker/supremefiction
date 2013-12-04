﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm.HotKey
{
    internal static class Win32
    {
        /// <summary>
        ///     Registers a shortcut on a global level.
        /// </summary>
        /// <param name="hwnd">
        ///     Handle to the window that will receive WM_HOTKEY messages generated by the hot key.
        ///     If this parameter is NULL, WM_HOTKEY messages are posted to the message queue of the calling thread and must be
        ///     processed in the message loop.
        /// </param>
        /// <param name="id">
        ///     Specifies the identifier of the hot key.
        ///     If the hWnd parameter is NULL, then the hot key is associated with the current thread rather than with a particular
        ///     window.
        ///     If a hot key already exists with the same hWnd and id parameters
        /// </param>
        /// <param name="modifiers">
        ///     Specifies keys that must be pressed in combination with the key specified by the Key parameter in order to generate
        ///     the WM_HOTKEY message.
        ///     The fsModifiers parameter can be a combination of the following values.
        ///     MOD_ALT
        ///     Either ALT key must be held down.
        ///     MOD_CONTROL
        ///     Either CTRL key must be held down.
        ///     MOD_SHIFT
        ///     Either SHIFT key must be held down.
        ///     MOD_WIN
        ///     Either WINDOWS key was held down. These keys are labelled with the Windows logo.
        ///     Keyboard shortcuts that involve the WINDOWS key are reserved for use by the operating system.
        /// </param>
        /// <param name="key">
        ///     Specifies the virtual-key code of the hot key.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern int RegisterHotKey(IntPtr hwnd, int id, int modifiers, int key);

        /// <summary>
        /// </summary>
        /// <param name="hwnd">
        ///     Handle to the window associated with the hot key to be freed.
        ///     This parameter should be NULL if the hot key is not associated with a window.
        /// </param>
        /// <param name="id">
        ///     Specifies the identifier of the hot key to be freed.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern int UnregisterHotKey(IntPtr hwnd, int id);

        /// <summary>
        ///     The SetWindowsHookEx function installs an application-defined hook procedure into a hook chain.
        ///     You would install a hook procedure to monitor the system for certain types of events. These events
        ///     are associated either with a specific thread or with all threads in the same desktop as the calling thread.
        /// </summary>
        /// <param name="idHook">
        ///     [in] Specifies the type of hook procedure to be installed. This parameter can be one of the following values.
        /// </param>
        /// <param name="lpfn">
        ///     [in] Pointer to the hook procedure. If the dwThreadId parameter is zero or specifies the identifier of a
        ///     thread created by a different process, the lpfn parameter must point to a hook procedure in a dynamic-link
        ///     library (DLL). Otherwise, lpfn can point to a hook procedure in the code associated with the current process.
        /// </param>
        /// <param name="hMod">
        ///     [in] Handle to the DLL containing the hook procedure pointed to by the lpfn parameter.
        ///     The hMod parameter must be set to NULL if the dwThreadId parameter specifies a thread created by
        ///     the current process and if the hook procedure is within the code associated with the current process.
        /// </param>
        /// <param name="dwThreadId">
        ///     [in] Specifies the identifier of the thread with which the hook procedure is to be associated.
        ///     If this parameter is zero, the hook procedure is associated with all existing threads running in the
        ///     same desktop as the calling thread.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is the handle to the hook procedure.
        ///     If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        ///     http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/windowing/hooks/hookreference/hookfunctions/setwindowshookex.asp
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,
            SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

        /// <summary>
        ///     Retrieves a module handle for the specified module.
        ///     The module must have been loaded by the calling process.
        /// </summary>
        /// <param name="lpModuleName">
        ///     The name of the loaded module (either a .dll or .exe file).
        ///     If the file name extension is omitted, the default library extension .dll is appended.
        ///     The file name string can include a trailing point character (.) to indicate that the module name has no extension.
        ///     The string does not have to specify a path. When specifying a path, be sure to use backslashes (\), not forward
        ///     slashes (/). The name is compared (case independently) to the names of modules currently mapped into the address
        ///     space of the calling process.
        ///     If this parameter is NULL, GetModuleHandle returns a handle to the file used to create the calling process (.exe
        ///     file).
        ///     The GetModuleHandle function does not retrieve handles for modules that were loaded using the
        ///     LOAD_LIBRARY_AS_DATAFILE flag.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a handle to the specified module.
        ///     If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);

        /// <summary>
        ///     The UnhookWindowsHookEx function removes a hook procedure installed in a hook chain by the SetWindowsHookEx
        ///     function.
        /// </summary>
        /// <param name="idHook">
        ///     [in] Handle to the hook to be removed. This parameter is a hook handle obtained by a previous call to
        ///     SetWindowsHookEx.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        ///     http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/windowing/hooks/hookreference/hookfunctions/setwindowshookex.asp
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,
            SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern int UnhookWindowsHookEx(IntPtr idHook);

        /// <summary>
        ///     The CallNextHookEx function passes the hook information to the next hook procedure in the current hook chain.
        ///     A hook procedure can call this function either before or after processing the hook information.
        /// </summary>
        /// <param name="idHook">Ignored.</param>
        /// <param name="nCode">
        ///     [in] Specifies the hook code passed to the current hook procedure.
        ///     The next hook procedure uses this code to determine how to process the hook information.
        /// </param>
        /// <param name="wParam">
        ///     [in] Specifies the wParam value passed to the current hook procedure.
        ///     The meaning of this parameter depends on the type of hook associated with the current hook chain.
        /// </param>
        /// <param name="lParam">
        ///     [in] Specifies the lParam value passed to the current hook procedure.
        ///     The meaning of this parameter depends on the type of hook associated with the current hook chain.
        /// </param>
        /// <returns>
        ///     This value is returned by the next hook procedure in the chain.
        ///     The current hook procedure must also return this value. The meaning of the return value depends on the hook type.
        ///     For more information, see the descriptions of the individual hook procedures.
        /// </returns>
        /// <remarks>
        ///     http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/windowing/hooks/hookreference/hookfunctions/setwindowshookex.asp
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,
            SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        ///     The MapVirtualKey function translates (maps) a virtual-key code into a scan code or character value, or translates
        ///     a scan code into a virtual-key code.
        /// </summary>
        /// <param name="uCode">
        ///     Specifies the virtual-key code or scan code for a key.
        ///     How this value is interpreted depends on the value of the uMapType parameter.
        /// </param>
        /// <param name="uMapType">Specifies the translation to perform.</param>
        /// <returns>
        ///     The return value is either a scan code, a virtual-key code, or a character value, depending on the value of uCode
        ///     and uMapType.
        ///     If there is no translation, the return value is zero.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern uint MapVirtualKey(uint uCode, uint uMapType);

        /// <summary>
        ///     The keybd_event function synthesizes a keystroke.
        ///     The system can use such a synthesized keystroke to generate a WM_KEYUP or WM_KEYDOWN message.
        /// </summary>
        /// <param name="key">Specifies a virtual-key code. The code must be a value in the range 1 to 254.</param>
        /// <param name="scan">
        ///     Specifies a hardware scan code for the key.
        /// </param>
        /// <param name="flags">
        ///     Specifies various aspects of function operation. This parameter can be one or more of the following values.
        ///     KEYEVENTF_EXTENDEDKEY
        ///     If specified, the scan code was preceded by a prefix byte having the value 0xE0 (224).
        ///     KEYEVENTF_KEYUP
        ///     If specified, the key is being released. If not specified, the key is being depressed.
        /// </param>
        /// <param name="extraInfo">
        ///     Specifies an additional value associated with the key stroke.
        /// </param>
        [DllImport("user32.dll")]
        internal static extern void keybd_event(byte key, byte scan, int flags, int extraInfo);

        internal static IntPtr SetWindowsHook(int hookType, HookProc callback)
        {
            IntPtr hookId;
            using (Process currentProcess = Process.GetCurrentProcess())
            using (ProcessModule currentModule = currentProcess.MainModule)
            {
                IntPtr handle = GetModuleHandle(currentModule.ModuleName);
                hookId = SetWindowsHookEx(hookType, callback, handle, 0);
            }
            return hookId;
        }

        /// <summary>
        ///     This delegate matches the type of parameter "lpfn" for the NativeMethods method "SetWindowsHookEx".
        ///     For more information: http://msdn.microsoft.com/en-us/library/ms644986(VS.85).aspx
        /// </summary>
        /// <param name="nCode">
        ///     Specifies whether the hook procedure must process the message.
        ///     If nCode is HC_ACTION, the hook procedure must process the message.
        ///     If nCode is less than zero, the hook procedure must pass the message to the
        ///     CallNextHookEx function without further processing and must return the
        ///     value returned by CallNextHookEx.
        /// </param>
        /// <param name="wParam">
        ///     Specifies whether the message was sent by the current thread.
        ///     If the message was sent by the current thread, it is nonzero; otherwise, it is zero.
        /// </param>
        /// <param name="lParam">
        ///     Pointer to a CWPSTRUCT structure that contains details about the message.
        /// </param>
        /// <returns>
        ///     If nCode is less than zero, the hook procedure must return the value returned by CallNextHookEx.
        ///     If nCode is greater than or equal to zero, it is highly recommended that you call CallNextHookEx
        ///     and return the value it returns; otherwise, other applications that have installed WH_CALLWNDPROC
        ///     hooks will not receive hook notifications and may behave incorrectly as a result. If the hook
        ///     procedure does not call CallNextHookEx, the return value should be zero.
        /// </returns>
        internal delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
    }
}