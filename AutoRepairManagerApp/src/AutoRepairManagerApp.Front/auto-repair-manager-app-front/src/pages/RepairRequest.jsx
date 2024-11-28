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
      const response = await fetch(
        "http://localhost:5271/api/Admin/RepairOrders",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(formData),
        }
      );

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
    <div className="flex items-center justify-center min-h-screen  bg-gray-100">
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
            <img
              src="data:image/jpeg;base64,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"
              alt="Пример техпаспорта"
            />
          </div>
        </div>
      )}
    </div>
  );
};

export default RepairRequest;
