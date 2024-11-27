import React, { useState, useEffect } from "react";

const RepairOrder = () => {
  const [repairRequests, setRepairRequests] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    // Функция для загрузки данных с API
    const fetchRepairRequests = async () => {
      try {
        const response = await fetch(
          "http://localhost:5271/api/Admin/RepairOrders"
        );
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        setRepairRequests(data); // Сохраняем данные в состояние
      } catch (err) {
        setError(err.message); // Обрабатываем ошибки
      } finally {
        setLoading(false); // Убираем состояние загрузки
      }
    };

    fetchRepairRequests(); // Запускаем запрос при монтировании компонента
  }, []);

  if (loading) {
    return <div className="p-8 text-gray-700">Loading...</div>;
  }

  if (error) {
    return <div className="p-8 text-red-500">Error: {error}</div>;
  }

  return (
    <div className="p-8 bg-gray-100 min-h-screen">
      <h1 className="text-3xl font-bold mb-6 text-gray-800">Repair Orders</h1>
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

export default RepairOrder;
