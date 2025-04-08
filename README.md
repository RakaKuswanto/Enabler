# Enabler - Window Control and Interaction Tool

This project is a Windows Forms application designed to enable and disable specific window controls, manipulate window states, and retrieve or set window text. It uses P/Invoke to interact with the Windows API (`user32.dll`) for window manipulation, including enabling/disabling windows, sending messages, and interacting with child windows.

### Key Features:
- **Enable/Disable Window Controls**: Toggle the enabled state of a target window.
- **Window Visibility Control**: Hide or show windows using `ShowWindow` from the Windows API.
- **Text Manipulation**: Retrieve and set text for a specific window control.
- **Child Window Enumeration**: Enumerate and display child windows of a target parent window in a TreeView.
- **Cursor Tracking for Window Targeting**: Use a custom cursor for targeting specific windows for manipulation.

### Key Functionalities:
- **Window Enabling/Disabling**: The application allows the user to enable or disable a window (button control) by sending specific messages to the window handle.
- **Text Management**: The user can set or retrieve text from a target window using `SendMessage` for controlling text within the window.
- **Child Window Enumeration**: The tool can list and display child windows of a parent window, allowing for easy navigation and control.
- **Custom Cursor for Targeting**: A crosshair cursor is used to help the user select a target window for manipulation.

### External Libraries:
- **user32.dll**: Interacts with various Windows API functions, including window manipulation, cursor position retrieval, and window messaging.

### Usage:
- Select a window using the targeting tool (click and drag the crosshair cursor to a window).
- Enable or disable the selected window, show or hide it, or manipulate its text.
- View and interact with child windows within the main window.

### Requirements:
- .NET Framework (Windows Forms)
- Windows OS (for interacting with Windows API)
