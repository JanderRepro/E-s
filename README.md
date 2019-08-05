# E-s
An app commissioned to track craft beer/bourbon releases.
All .cs files are run in the Unity app on the client's device, all .php files are run on the server-end. Some lines are partially redacted for security reasons.
Unity was admittedly not the ideal platform for such an app, but it serves as a decent example of how to link Unity with an online database.

When main search function is executed, app attempts to retrieve user's GPS location.
If successful, it calls an SQL query to list all events where "endtime" is later than present time. "starttime" is ignored for now.
The query joins each event with its associated venue. When the information reaches the app, it compares the user's location
with each event/venue location. If the locations are within the user-specified range, the event is displayed to the user, ordered by "starttime."
The arrangement allows for events that are currently in-progress to be listed.
