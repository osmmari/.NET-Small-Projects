using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace Ddd.Taxi.Domain
{
	// In real aplication it whould be the place where database is used to find driver by its Id.
	// But in this exercise it is just a mock to simulate database
	public class DriversRepository
	{
		public void FillDriverToOrder(int driverId, TaxiOrder order)
		{
			if (driverId == 15)
			{
				order.DriverId = driverId;
				order.DriverFirstName = "Drive";
				order.DriverLastName = "Driverson";
				order.CarModel = "Lada sedan";
				order.CarColor = "Baklazhan";
				order.CarPlateNumber = "A123BT 66";
			}
			else
				throw new Exception("Unknown driver id " + driverId);
		}
	}

	public class TaxiApi : ITaxiApi<TaxiOrder>
	{
		private readonly DriversRepository driversRepo;
		private readonly Func<DateTime> currentTime;
		private int idCounter;

		public TaxiApi(DriversRepository driversRepo, Func<DateTime> currentTime)
		{
			this.driversRepo = driversRepo;
			this.currentTime = currentTime;
		}

		public TaxiOrder CreateOrderWithoutDestination(string firstName, string lastName, string street, string building)
		{
			return
				new TaxiOrder
				{
					Id = idCounter++,
					ClientFirstName = firstName,
					ClientLastName = lastName,
					StartStreet = street,
					StartBuilding = building,
					CreationTime = currentTime()
				};
		}

		public void UpdateDestination(TaxiOrder order, string street, string building)
		{
			order.DestinationStreet = street;
			order.DestinationBuilding = building;
		}

		public void AssignDriver(TaxiOrder order, int driverId)
		{
			driversRepo.FillDriverToOrder(driverId, order);
			order.DriverAssignmentTime = currentTime();
			order.Status = TaxiOrderStatus.WaitingCarArrival;
		}

		public void UnassignDriver(TaxiOrder order)
		{
			order.DriverFirstName = null;
			order.DriverLastName = null;
			order.CarModel = null;
			order.CarColor = null;
			order.CarPlateNumber = null;
			order.Status = TaxiOrderStatus.WaitingForDriver;
		}

		public string GetDriverFullInfo(TaxiOrder order)
		{
			if (order.Status == TaxiOrderStatus.WaitingForDriver) return null;
			return string.Join(" ",
				"Id: " + order.DriverId,
				"DriverName: " + FormatName(order.DriverFirstName, order.DriverLastName),
				"Color: " + order.CarColor,
				"CarModel: " + order.CarModel,
				"PlateNumber: " + order.CarPlateNumber);
		}

		public string GetShortOrderInfo(TaxiOrder order)
		{
			return string.Join(" ",
				"OrderId: " + order.Id,
				"Status: " + order.Status,
				"Client: " + FormatName(order.ClientFirstName, order.ClientLastName),
				"Driver: " + FormatName(order.DriverFirstName, order.DriverLastName),
				"From: " + FormatAddress(order.StartStreet, order.StartBuilding),
				"To: " + FormatAddress(order.DestinationStreet, order.DestinationBuilding),
				"LastProgressTime: " + GetLastProgressTime(order).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
		}

		private DateTime GetLastProgressTime(TaxiOrder order)
		{
			if (order.Status == TaxiOrderStatus.WaitingForDriver) return order.CreationTime;
			if (order.Status == TaxiOrderStatus.WaitingCarArrival) return order.DriverAssignmentTime;
			if (order.Status == TaxiOrderStatus.InProgress) return order.StartRideTime;
			if (order.Status == TaxiOrderStatus.Finished) return order.FinishRideTime;
			if (order.Status == TaxiOrderStatus.Canceled) return order.CancelTime;
			throw new NotSupportedException(order.Status.ToString());
		}

		private string FormatName(string firstName, string lastName)
		{
			return string.Join(" ", new[] { firstName, lastName }.Where(n => n != null));
		}

		private string FormatAddress(string street, string building)
		{
			return string.Join(" ", new[] { street, building }.Where(n => n != null));
		}

		public void Cancel(TaxiOrder order)
		{
			order.Status = TaxiOrderStatus.Canceled;
			order.CancelTime = currentTime();
		}

		public void StartRide(TaxiOrder order)
		{
			order.Status = TaxiOrderStatus.InProgress;
			order.StartRideTime = currentTime();
		}

		public void FinishRide(TaxiOrder order)
		{
			order.Status = TaxiOrderStatus.Finished;
			order.FinishRideTime = currentTime();
		}
	}

	public class TaxiOrder
	{
		public int Id;
		public string ClientFirstName;
		public string ClientLastName;
		public string StartStreet;
		public string StartBuilding;
		public string DestinationStreet;
		public string DestinationBuilding;
		public int DriverId;
		public string DriverFirstName;
		public string DriverLastName;
		public string CarColor;
		public string CarModel;
		public string CarPlateNumber;
		public TaxiOrderStatus Status;
		public DateTime CreationTime;
		public DateTime DriverAssignmentTime;
		public DateTime CancelTime;
		public DateTime StartRideTime;
		public DateTime FinishRideTime;
	}
}