@echo off
REM https://help.rejseplanen.dk/hc/da/articles/214174565-ReST-API-Stoppestedsdata-GTFS
REM Tool: https://www.nuget.org/packages/dotnet-xscgen/

xscgen -o .. -n =MBW.Clients.Rejseplanen.Schema.RestLocation hafasRestLocation.xsd
xscgen -o .. -n =MBW.Clients.Rejseplanen.Schema.RestTrip hafasRestTrip.xsd
xscgen -o .. -n =MBW.Clients.Rejseplanen.Schema.RestJourneyDetail hafasRestJourneyDetail.xsd
xscgen -o .. -n =MBW.Clients.Rejseplanen.Schema.RestDepartureBoard hafasRestDepartureBoard.xsd
xscgen -o .. -n =MBW.Clients.Rejseplanen.Schema.RestArrivalBoard hafasRestArrivalBoard.xsd
xscgen -o .. -n =MBW.Clients.Rejseplanen.Schema.RestStopsNearby hafasRestStopsNearby.xsd
xscgen -o .. -n =MBW.Clients.Rejseplanen.Schema.RestMultiDepartureBoard hafasRestMultiDepartureBoard.xsd
