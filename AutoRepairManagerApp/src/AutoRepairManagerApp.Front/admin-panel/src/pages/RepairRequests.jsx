import React from "react";

const repairRequests = [
  {
    id: 1,
    username: "JohnDoe",
    carInfo: "Toyota Corolla 2020, License Plate: AB123CD",
    problemDescription: "Engine makes a loud noise when starting.",
  },
  {
    id: 2,
    username: "JaneSmith",
    carInfo: "Honda Civic 2018, License Plate: XY456EF",
    problemDescription: "Brake system needs a checkup.",
  },
  {
    id: 3,
    username: "MikeBrown",
    carInfo: "BMW X5 2021, License Plate: GH789IJ",
    problemDescription: "Air conditioning is not working properly.",
  },
];

const RepairRequest = () => {
  return (
    <div className="p-8 bg-gray-100 min-h-screen">
      <h1 className="text-3xl font-bold mb-6 text-gray-800">Repair Requests</h1>
      <div className="bg-white shadow rounded-lg p-6">
        <table className="w-full text-left border-collapse">
          <thead>
            <tr className="bg-gray-200">
              <th className="p-4 border-b text-gray-700">#</th>
              <th className="p-4 border-b text-gray-700">Username</th>
              <th className="p-4 border-b text-gray-700">Car Info</th>
              <th className="p-4 border-b text-gray-700">
                Problem Description
              </th>
              <th className="p-4 border-b text-gray-700">Actions</th>
            </tr>
          </thead>
          <tbody>
            {repairRequests.map((request, index) => (
              <tr
                key={request.id}
                className={index % 2 === 0 ? "bg-gray-50" : "bg-white"}
              >
                <td className="p-4 border-b">{request.id}</td>
                <td className="p-4 border-b">{request.username}</td>
                <td className="p-4 border-b">{request.carInfo}</td>
                <td className="p-4 border-b">{request.problemDescription}</td>
                <td className="p-4 border-b">
                  <button className="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600">
                    Approve
                  </button>
                  <button className="ml-2 px-4 py-2 bg-red-500 text-white rounded hover:bg-red-600">
                    Reject
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default RepairRequest;
