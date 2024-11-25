import React, { useState } from "react";

const RepairRequest = () => {
  const [formData, setFormData] = useState({
    name: "",
    phone: "",
    technicalpassport: "",
    carBrand: "",
    carModel: "",
    issueDescription: "",
  });

  const [isSubmitted, setIsSubmitted] = useState(false);
  const [isModalOpen, setIsModalOpen] = useState(false); // Для модального окна

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch("https://your-api-url.com/repair-requests", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(formData),
      });

      if (response.ok) {
        setIsSubmitted(true);
        setFormData({
          name: "",
          phone: "",
          technicalpassport: "",
          carBrand: "",
          carModel: "",
          issueDescription: "",
        });
      } else {
        console.error("Failed to submit the form.");
      }
    } catch (error) {
      console.error("Error submitting the form:", error);
    }
  };

  return (
    <div className="flex items-center justify-center min-h-screen bg-gray-100">
      <div className="bg-white shadow-2xl rounded-lg p-8 w-full max-w-lg border border-gray-300">
        <h1 className="text-3xl font-bold text-gray-800 mb-6 text-center">
          Запрос на ремонт
        </h1>
        {isSubmitted ? (
          <div className="text-center">
            <p className="text-green-600 text-lg">
              Ваш запрос успешно отправлен!
            </p>
          </div>
        ) : (
          <form onSubmit={handleSubmit}>
            <div className="mb-6">
              <label
                htmlFor="name"
                className="block text-sm font-medium text-gray-700"
              >
                Имя Фамилия
              </label>
              <input
                type="text"
                id="name"
                name="name"
                value={formData.name}
                onChange={handleChange}
                className="mt-2 p-3 block w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500"
                required
              />
            </div>

            <div className="mb-6">
              <label
                htmlFor="phone"
                className="block text-sm font-medium text-gray-700"
              >
                Номер телефона
              </label>
              <input
                type="tel"
                id="phone"
                name="phone"
                value={formData.phone}
                onChange={handleChange}
                className="mt-2 p-3 block w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500"
                required
              />
            </div>

            <div className="mb-6 relative">
              <label
                htmlFor="technicalpassport"
                className="block text-sm font-medium text-gray-700"
              >
                Номер тех.паспорта
              </label>
              <div className="flex items-center">
                <input
                  type="text"
                  id="technicalpassport"
                  name="technicalpassport"
                  value={formData.technicalpassport}
                  onChange={handleChange}
                  className="mt-2 p-3 block w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500"
                  required
                />
                <button
                  type="button"
                  className="ml-2 text-gray-500 hover:text-blue-500"
                  onClick={() => setIsModalOpen(true)}
                >
                  ℹ️
                </button>
              </div>
            </div>

            <div className="mb-6">
              <label
                htmlFor="carBrand"
                className="block text-sm font-medium text-gray-700"
              >
                Марка автомобиля
              </label>
              <input
                type="text"
                id="carBrand"
                name="carBrand"
                value={formData.carBrand}
                onChange={handleChange}
                className="mt-2 p-3 block w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500"
                required
              />
            </div>

            <div className="mb-6">
              <label
                htmlFor="carModel"
                className="block text-sm font-medium text-gray-700"
              >
                Модель автомобиля
              </label>
              <input
                type="text"
                id="carModel"
                name="carModel"
                value={formData.carModel}
                onChange={handleChange}
                className="mt-2 p-3 block w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500"
                required
              />
            </div>

            <div className="mb-6">
              <label
                htmlFor="issueDescription"
                className="block text-sm font-medium text-gray-700"
              >
                Описание проблемы
              </label>
              <textarea
                id="issueDescription"
                name="issueDescription"
                value={formData.issueDescription}
                onChange={handleChange}
                className="mt-2 p-3 block w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500"
                rows="4"
                required
              ></textarea>
            </div>

            <button
              type="submit"
              className="w-full bg-blue-600 text-white py-3 rounded-md hover:bg-blue-700 focus:ring-4 focus:ring-blue-300"
            >
              Отправить запрос
            </button>
          </form>
        )}
      </div>

      {/* Модальное окно */}
      {isModalOpen && (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center">
          <div className="bg-white p-6 rounded-lg shadow-lg relative">
            <button
              className="absolute top-2 right-2 text-gray-600 hover:text-gray-900"
              onClick={() => setIsModalOpen(false)}
            >
              ✖️
            </button>
            <h2 className="text-lg font-semibold mb-4">Пример техпаспорта</h2>
            <p>Тут будет ваше изображение</p>
          </div>
        </div>
      )}
    </div>
  );
};

export default RepairRequest;
