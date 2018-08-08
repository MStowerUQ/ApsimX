﻿using Cairo;
using Gtk;
using System;
using UserInterface.Views;
using UserInterface.EventArguments;

namespace UserInterface.Interfaces
{
    public interface IMainView
    {
        /// <summary>
        /// Get the start page 1 view
        /// </summary>
        IListButtonView StartPage1 { get; }

        /// <summary>
        /// Get the start page 2 view
        /// </summary>
        IListButtonView StartPage2 { get; }

        /// <summary>Add a tab form to the tab control. Optionally select the tab if SelectTab is true.</summary>
        /// <param name="text">Text for tab.</param>
        /// <param name="image">Image for tab.</param>
        /// <param name="control">Control for tab.</param>
        /// <param name="onLeftTabControl">If true a tab will be added to the left hand tab control.</param>
        void AddTab(string text, Image image, Widget control, bool onLeftTabControl);

        /// <summary>Change the text of a tab.</summary>
        /// <param name="currentTabName">Current tab text.</param>
        /// <param name="newTabName">New text of the tab.</param>
        void ChangeTabText(object ownerView, string newTabName, string tooltip);

        /// <summary>
        /// The main window.
        /// </summary>
        Gdk.Window MainWindow { get; }

        /// <summary>
        /// Location of the main window.
        /// </summary>
        System.Drawing.Point WindowLocation { get; set; }

        /// <summary>
        /// Gets or set the main window size.
        /// </summary>
        System.Drawing.Size WindowSize { get; set; }

        /// <summary>
        /// Gets or set the main window size.
        /// </summary>
        bool WindowMaximised { get; set; }

        /// <summary>
        /// Gets or set the main window size.
        /// </summary>
        string WindowCaption { get; set; }

        /// <summary>
        /// Turn split window on/off
        /// </summary>
        bool SplitWindowOn { get; set; }

        /// <summary
        /// >Height of the status panel
        /// </summary>
        int StatusPanelHeight { get; set; }

        /// <summary>
        ///  Default font size, in points.
        /// </summary>
        double FontSize { get; set; }

        /// <summary>
        /// Used to modify the cursor. If set to true, the waiting cursor will be displayed.
        /// If set to false, the default cursor will be used.
        /// </summary>
        bool WaitCursor { get; set; }

        /// <summary>
        /// Returns true if the object is a control on the left side
        /// </summary>
        bool IsControlOnLeft(object control);

        /// <summary>
        /// Gets a menu item from a file name?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string GetMenuItemFileName(object obj);

        /// <summary>Ask user for a filename to open.</summary>
        /// <param name="fileSpec">The file specification to use to filter the files.</param>
        /// <param name="initialDirectory">Optional Initial starting directory</param>
        string AskUserForOpenFileName(string fileSpec, string initialDirectory = "");

        /// <summary>
        /// A helper function that asks user for a SaveAs name and returns their new choice.
        /// </summary>
        /// <param name="fileSpec">The file specification to filter the files.</param>
        /// <param name="OldFilename">The current file name.</param>
        /// <returns>Returns the new file name or null if action cancelled by user.</returns>
        string AskUserForSaveFileName(string fileSpec, string OldFilename);

        /// <summary>Ask the user a question</summary>
        /// <param name="message">The message to show the user.</param>
        QuestionResponseEnum AskQuestion(string message);

        /// <summary>
        /// Add a status message. A message of null will clear the status message.
        /// </summary>
        /// <param name="Message">Message to be displayed.</param>
        /// <param name="errorLevel">Error level of the message. Affects the colour of message text.</param>
        /// <param name="overwrite">
        /// If true, all existing messages will be overridden.
        /// If false, message will be appended to the status window.
        /// </param>
        /// <param name="addSeparator">If true, a 'separator' (several dashes) will also be written to the status window.</param>
        /// <param name="withButton">
        /// Whether or not a 'more info' button should be drawn under the message. 
        /// If the message is not an error, this parameter has no effect.
        /// </param>
        void ShowMessage(string Message, Models.Core.Simulation.ErrorLevel errorLevel, bool overwrite = true, bool addSeparator = false, bool withButton = true);

        /// <summary>
        /// Displays an error message with a 'more info' button.
        /// </summary>
        /// <param name="err">Error for which we want to display information.</param>
        void ShowError(Exception err);

        /// <summary>Show a message in a dialog box</summary>
        /// <param name="message">The message.</param>
        /// <param name="errorLevel">The error level.</param>
        int ShowMsgDialog(string message, string title, MessageType msgType, ButtonsType buttonType, Window masterWindow = null);

        /// <summary>
        /// Checks if the assembly contains a given resource.
        /// </summary>
        /// <param name="name">Name of the resource.</param>
        /// <returns>True if the assembly contains the resource. False otherwise.</returns>
        bool HasResource(string name);

        /// <summary>
        /// Loads a Gtk builder object from a resource.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>Gtk builder object.</returns>
        Builder BuilderFromResource(string resourceName);

        /// <summary>
        /// Show progress bar with the specified percent.
        /// </summary>
        /// <param name="percent"></param>
        void ShowProgress(int percent, bool showStopButton = true);

        /// <summary>
        /// Set the wait cursor (or not).
        /// </summary>
        /// <param name="wait">Shows wait cursor if true, normal cursor if false.</param>
        void ShowWaitCursor(bool wait);

        /// <summary>
        /// Display the window.
        /// </summary>
        void Show();

        /// <summary>
        /// Close the application.
        /// </summary>
        /// <param name="askToSave">If true, will ask user whether they want to save.</param>
        void Close(bool askToSave = true);

        /// <summary>
        /// Close a tab.
        /// </summary>
        /// <param name="o">A widget appearing on the tab</param>
        void CloseTabContaining(object o);

        /// <summary>
        /// Select a tab.
        /// </summary>
        /// <param name="o">A widget appearing on the tab</param>
        void SelectTabContaining(object o);

        /// <summary>
        /// Gets the text from a clipboard.
        /// </summary>
        /// <param name="clipboardName">Name of the clipboard.</param>
        /// <returns>Text on the clipboard.</returns>
        string GetClipboardText(string clipboardName);

        /// <summary>
        /// Copies text to a clipboard.
        /// </summary>
        /// <param name="text">Text to be copied.</param>
        /// <param name="clipboardName">Name of the clipboard.</param>
        void SetClipboardText(string text, string clipboardName);

        /// <summary>
        /// Ask the user for a directory. Returns the path to that directory, or null if they did not choose a directory.
        /// </summary>
        /// <param name="prompt">String to use as dialog heading.</param>
        /// <param name="initialPath">Optional initial starting filename or directory.</param>
        /// <returns>string containing the path to the chosen directory.</returns>
        string AskUserForDirectory(string prompt, string initialPath = "");

        /// <summary>Ask user for a filename to open.</summary>
        /// <param name="prompt">String to use as dialog heading</param>
        /// <param name="fileSpec">The file specification used to filter the files.</param>
        /// <param name="action">Action to perform (currently either "Open" or "Save")</param>
        /// <param name="initialPath">Optional Initial starting filename or directory</param>      
        string AskUserForFileName(string prompt, string fileSpec, FileChooserAction action = FileChooserAction.Open, string initialPath = "");

        /// <summary>
        /// Invoked when application tries to close
        /// </summary>
        event EventHandler<AllowCloseArgs> AllowClose;

        /// <summary>
        /// Invoked when a tab is closing.
        /// </summary>
        event EventHandler<TabClosingEventArgs> TabClosing;

        /// <summary>
        /// Invoked when application tries to close
        /// </summary>
        event EventHandler<EventArgs> StopSimulation;

        /// <summary>
        /// Show a detailed error.
        /// </summary>
        event EventHandler ShowDetailedError;

        /// <summary>
        /// Invoked when an error has been thrown in a view.
        /// </summary>
        event EventHandler<ErrorArgs> OnError;
    }
}
