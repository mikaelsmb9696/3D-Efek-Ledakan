# 3D-Efek-Ledakan
1.	LedakanSO.cs
Function:
•	Edit blast properties (EditBlast) such as scale, duration, radius, and number of sparks.
•	Randomly fetch audio from the template collection (FetchAudio).
2.	TemplateLedakan.cs
Function: 
•	Data template to define the types of blasts (visual and sound) that can be used.
3.	SpawnerLedakan.cs
Function:
•	Set when and where explosions appear.
4.	PoolerLedakan.cs
Function:
•	Manages performance savings by creating a pool system for explosions so that there is no redundant Instantiate or Destroy.
