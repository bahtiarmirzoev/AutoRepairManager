import React, { useState } from "react";
import { FaUser, FaEnvelope, FaPhone, FaEdit } from "react-icons/fa";

const Profile = () => {
  const [userData, setUserData] = useState({
    firstName: "Иван",
    email: "ivan.ivanov@example.com",
    phone: "+7 (999) 123-45-67",
  });

  const [isEditing, setIsEditing] = useState(false);

  const repairHistory = [
    { id: 1, date: "2024-10-12", description: "Замена масла" },
    { id: 2, date: "2024-09-30", description: "Ремонт двигателя" },
    { id: 3, date: "2024-08-15", description: "Диагностика тормозов" },
  ];

  const repairDetails = [
    {
      id: 1,
      date: "2024-10-12",
      description: "Моторное масло",
      price: "75 AZN",
    },
    {
      id: 2,
      date: "2024-10-12",
      description: "Свечи зажигания",
      price: "55 AZN",
    },
    {
      id: 3,
      date: "2024-10-12",
      description: "Тормозные суппарта",
      price: "40 AZN",
    },
  ];

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setUserData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSave = () => {
    setIsEditing(false);
    console.log("Изменённые данные:", userData);
  };
  const handleAccept = (id) => {
    console.log(`Запрос с ID ${id} принят.`);
    // Добавьте здесь логику для обработки принятия.
  };

  const handleReject = (id) => {
    console.log(`Запрос с ID ${id} отклонён.`);
    // Добавьте здесь логику для обработки отказа.
  };

  return (
    <div className="flex flex-col md:flex-row bg-gradient-to-br from-gray-50 to-gray-100 p-8 min-h-screen space-y-6 md:space-y-0 md:space-x-6">
      {/* Личная информация */}
      <div className="w-full md:w-2/3 bg-white shadow-xl rounded-2xl p-8">
        <div className="flex justify-between items-center mb-6">
          <h2 className="text-3xl font-bold text-gray-800 border-b-4 border-blue-500 pb-3">
            Личная информация
          </h2>
          {!isEditing && (
            <button
              onClick={() => setIsEditing(true)}
              className="text-blue-600 hover:text-blue-700 flex items-center space-x-2"
            >
              <FaEdit className="text-lg" />
              <span>Изменить</span>
            </button>
          )}
        </div>
        {!isEditing ? (
          <div className="space-y-5 text-gray-700">
            <div className="flex items-center space-x-4">
              <FaUser className="text-blue-500 text-2xl" />
              <p className="text-xl font-medium">{userData.firstName}</p>
            </div>

            <div className="flex items-center space-x-4">
              <FaEnvelope className="text-blue-500 text-2xl" />
              <p className="text-xl">{userData.email}</p>
            </div>
            <div className="flex items-center space-x-4">
              <FaPhone className="text-blue-500 text-2xl" />
              <p className="text-xl">{userData.phone}</p>
            </div>
          </div>
        ) : (
          <div className="space-y-4">
            <div>
              <label className="text-lg font-medium block mb-2">Имя:</label>
              <input
                type="text"
                name="firstName"
                value={userData.firstName}
                onChange={handleInputChange}
                className="w-full p-3 border rounded-xl shadow-inner focus:outline-none focus:ring focus:ring-blue-300"
              />
            </div>

            <div>
              <label className="text-lg font-medium block mb-2">Email:</label>
              <input
                type="email"
                name="email"
                value={userData.email}
                onChange={handleInputChange}
                className="w-full p-3 border rounded-xl shadow-inner focus:outline-none focus:ring focus:ring-blue-300"
              />
            </div>
            <div>
              <label className="text-lg font-medium block mb-2">
                Номер телефона:
              </label>
              <input
                type="tel"
                name="phone"
                value={userData.phone}
                onChange={handleInputChange}
                className="w-full p-3 border rounded-xl shadow-inner focus:outline-none focus:ring focus:ring-blue-300"
              />
            </div>
            <div className="mt-4 flex justify-end space-x-4">
              <button
                onClick={() => setIsEditing(false)}
                className="px-4 py-2 bg-gray-300 text-gray-800 rounded-lg hover:bg-gray-400"
              >
                Отмена
              </button>
              <button
                onClick={handleSave}
                className="px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700"
              >
                Сохранить
              </button>
            </div>
          </div>
        )}
      </div>

      {/* История ремонтов */}
      <div className="w-full md:w-1/3 bg-white shadow-xl rounded-2xl p-8">
        <h2 className="text-3xl font-bold mb-6 text-gray-800 border-b-4 border-blue-500 pb-3">
          История ремонтов
        </h2>
        <ul className="space-y-4">
          {repairHistory.map((repair) => (
            <li
              key={repair.id}
              className="p-4 bg-gray-50 rounded-lg shadow-lg hover:shadow-xl transition-shadow duration-300"
            >
              <p className="text-lg font-semibold text-gray-800">
                {repair.description}
              </p>
              <p className="text-sm text-gray-600 mt-2">{repair.date}</p>
            </li>
          ))}
        </ul>
      </div>

      <div className="w-full md:w-1/3 bg-white shadow-xl rounded-2xl p-8">
        <h2 className="text-3xl font-bold mb-6 text-gray-800 border-b-4 border-blue-500 pb-3">
          Запросы на запчасти
        </h2>
        <ul className="space-y-4">
          {repairDetails.map((detail) => (
            <li
              key={detail.id}
              className="p-4 bg-gray-50 rounded-lg shadow-lg hover:shadow-xl transition-shadow duration-300"
            >
              <p className="text-lg font-semibold text-gray-800">
                {detail.description}
              </p>
              <p className="text-sm text-gray-600 mt-2">{detail.date}</p>
              <p className="text-sm text-gray-600 mt-1">Цена: {detail.price}</p>
              <div className="flex space-x-4 mt-4">
                <button
                  onClick={() => handleAccept(detail.id)}
                  className="px-4 py-2 bg-green-500 text-white rounded-lg hover:bg-green-600 transition-colors duration-200"
                >
                  Принять
                </button>
                <button
                  onClick={() => handleReject(detail.id)}
                  className="px-4 py-2 bg-red-500 text-white rounded-lg hover:bg-red-600 transition-colors duration-200"
                >
                  Отказать
                </button>
              </div>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default Profile;
