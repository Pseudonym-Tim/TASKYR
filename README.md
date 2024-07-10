# TASKYR 
#### <b>"Empower Focus, Enhance Productivity: Building the ultimate tool to prevent procrastination and distractions"</b>
TASKYR is a simple yet powerful productivity tool designed to help you stay focused and manage your time effectively. Developed using C# and WinForms on the .NET framework, TASKYR provides essential features to block distracting programs and websites, allowing you to concentrate on what truly matters.

## Features:
* Program Blocking: Prevent specified programs from running during your focus time.
* Website Blocking: Block access to distracting websites to keep you on track.
* Whitelist: Maintain a list of allowed programs and websites that are essential for your work.
* Scheduled Blocking: Set up specific times when blocking rules should be active. For example, block distractions from 12:00 PM to 8:00 PM.
* Day Selection: Choose which days of the week the blocking rules should apply. Whether you need focus time only on weekdays or specific days like Monday, Wednesday, and Friday, TASKYR has you covered.

## Images:
<img src="https://pseudonym-tim.dev/img/projects/taskyr/taskyr-1.PNG" alt="Image 1" width="700"/>
<img src="https://pseudonym-tim.dev/img/projects/taskyr/taskyr-2.PNG" alt="Image 2" width="700"/>

## Installation:
To install TASKYR, just download a release build! If you want to build it yourself, you can follow these steps:

1.) Clone the repository:
```git clone https://github.com/Pseudonym-Tim/TASKYR.git```
</br> 2.) Open the project in your preferred C# development environment (e.g., Visual Studio).
</br> 3.) Build the project to restore dependencies and compile the application.
</br> 4.) Run the application from your development environment or build an executable to run TASKYR independently.
# Using the Application:
## Configure Blocking:

Add websites to block by entering the URL in the input box and clicking "Add Website".
</br>Add running programs to block by clicking "Add Program" and select an executable file manually using the file picker.
## Configure Schedule:

Set up your blocking schedule by clicking "Configure Schedule" and selecting the days and times you want blocking to be active.
## Start Blocking:

Click the "Start Working!" button to begin a work session. The application will block the specified websites and programs according to your settings and schedule.
## Blocking Websites:
The application modifies the hosts file on your system to block websites by redirecting them to 127.0.0.1.

## Blocking Programs:
The application monitors running processes and attempts to close any that are listed as blocked.

## Configuration:
When the application starts, it will attempt to load settings from settings.json. If this file exists, it will automatically populate the application with your previous configurations.

## Save Settings:
Your settings and options will be saved automatically upon exiting the program. This will write your configurations to settings.json for future sessions.

## Scheduling:
To configure your blocking schedule:
</br>
</br> 1.) Click the "Configure Schedule" button.
</br> 2.) Select the days of the week you want blocking to be active.
</br> 3.) Set the start and end times for each selected day.
</br> 4.) Save your schedule.
</br> 5.) Saving and Loading Settings
</br> 6.) Settings are automatically loaded from settings.json when the application starts.

## Stopping Work Sessions:
To stop a work session:

Click the "Stop Working!" button.
If blocking is currently active, you will be prompted to confirm the action by typing a short essay.
