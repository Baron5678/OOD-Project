using NetworkSourceSimulator;
using OODProj.Data;
using OODProj.Data.Users;
using OODProj.GUI;
using OODProj.Logging;
using NSS = NetworkSourceSimulator;

namespace OODProj.UpdateDataService
{
    public class UpdateService
    {
        private Thread _server;

        public UpdateService(string path)
        {
            NSS.NetworkSourceSimulator updater = new(path, 1, 1);
            updater.OnIDUpdate += Updater_OnIDUpdate;
            updater.OnPositionUpdate += Updater_OnPositionUpdate;
            updater.OnContactInfoUpdate += Updater_OnContactInfoUpdate;
            _server = new Thread(updater.Run);
            _server.IsBackground = true;
        }

        private void Updater_OnContactInfoUpdate(object sender, ContactInfoUpdateArgs args)
        {
            if (StorageIDs.Objectsset.ContainsKey(args.ObjectID))
            {
                var userObject = StorageIDs.UserObjects[args.ObjectID];
                userObject.Email = args.EmailAddress;
                userObject.Phone = args.PhoneNumber;
            }
            else 
            {
                var state = new ErrorState();
                state.ObjectName = "UpdateService";
                state.ErrorMessage = $"Object with ID {args.ObjectID} not found in StorageIDs.UserObjects";
                Log.Instance.LogWrite(state);
            }
        }

        private void Updater_OnPositionUpdate(object sender, PositionUpdateArgs args)
        {
            if (StorageIDs.PositionedObjects.ContainsKey(args.ObjectID))
            {
                var posObject = StorageIDs.PositionedObjects[args.ObjectID];
                posObject.Longitude = args.Longitude;
                posObject.Latitude = args.Latitude;
                posObject.AMSL = args.AMSL;
                if (posObject is Flight)
                {
                    FlightUpdateService.IsUpdated = true;
                }
            }
            else
            {
                var state = new ErrorState();
                state.ObjectName = "UpdateService";
                state.ErrorMessage = $"Object with ID {args.ObjectID} not found in StorageIDs.PositionedObjects";
                Log.Instance.LogWrite(state);
            }
        }

        private void Updater_OnIDUpdate(object sender, IDUpdateArgs args)
        {
            if (StorageIDs.Objectsset.ContainsKey(args.ObjectID))
            {
                var pkObj = StorageIDs.Objectsset[args.ObjectID];

                if (!StorageIDs.IDset.Contains(args.NewObjectID))
                {
                    pkObj.PrevID = args.ObjectID;
                    pkObj.ID = args.NewObjectID;
                    StorageIDs.Objectsset.Remove(args.ObjectID);
                    StorageIDs.Objectsset.Add(args.NewObjectID, pkObj);
                    if (StorageIDs.UserObjects.ContainsKey(args.ObjectID))
                    {
                        StorageIDs.UserObjects.Remove(args.ObjectID);
                        StorageIDs.UserObjects.Add(args.NewObjectID, (IUser)pkObj);
                    }
                    else if (StorageIDs.PositionedObjects.ContainsKey(args.ObjectID))
                    {
                        StorageIDs.PositionedObjects.Remove(args.ObjectID);
                        StorageIDs.PositionedObjects.Add(args.NewObjectID, (IPositioned)pkObj);
                    }
                    else
                    {
                        var state = new ErrorState();
                        state.ObjectName = "UpdateService";
                        state.ErrorMessage = $"Object with ID {args.ObjectID} not found in StorageIDs.UserObjects or StorageIDs.PositionedObjects";
                        Log.Instance.LogWrite(state);
                    }

                }
                else
                {
                    var state = new ErrorState();
                    state.ObjectName = "UpdateService";
                    state.ErrorMessage = $"Object with ID {args.NewObjectID} already exists in StorageIDs.IDset";
                    Log.Instance.LogWrite(state);
                }
            }
            else
            {
                var state = new ErrorState();
                state.ObjectName = "UpdateService";
                state.ErrorMessage = $"Object with ID {args.ObjectID} not found in StorageIDs.Objectsset";
                Log.Instance.LogWrite(state);
            }
        }

        public void Update()
            => _server.Start();
    }
}
