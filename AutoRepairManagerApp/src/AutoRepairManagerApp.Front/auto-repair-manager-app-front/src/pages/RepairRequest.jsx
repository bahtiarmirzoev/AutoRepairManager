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
    <div className="flex items-center justify-center min-h-screen bg-blue-50">
      <div className="bg-white shadow-lg rounded-lg p-8 w-full max-w-md">
        <h1 className="text-2xl font-bold text-blue-600 mb-4">
          Запрос на ремонт
        </h1>
        {isSubmitted ? (
          <div className="text-center">
            <p className="text-green-600">Ваш запрос успешно отправлен!</p>
          </div>
        ) : (
          <form onSubmit={handleSubmit}>
            <div className="mb-4">
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
                className="mt-1 p-2 block w-full border rounded-md"
                required
              />
            </div>

            <div className="mb-4">
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
                className="mt-1 p-2 block w-full border rounded-md"
                required
              />
            </div>
            <div className="mb-4">
              <label
                htmlFor="phone"
                className="block text-sm font-medium text-gray-700"
              >
                Номер тех.паспорта
              </label>
              <input
                type="techpass"
                id="techpass"
                name="techpass"
                value={formData.technicalpassport}
                onChange={handleChange}
                className="mt-1 p-2 block w-full border rounded-md"
                required
              />
            </div>

            <div className="mb-4">
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
                className="mt-1 p-2 block w-full border rounded-md"
                required
              />
            </div>

            <div className="mb-4">
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
                className="mt-1 p-2 block w-full border rounded-md"
                required
              />
            </div>

            <div className="mb-4">
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
                className="mt-1 p-2 block w-full border rounded-md"
                rows="4"
                required
              ></textarea>
            </div>

            <button
              type="submit"
              className="w-full bg-blue-600 text-white py-2 rounded-md hover:bg-blue-700"
            >
              Отправить запрос
            </button>
          </form>
        )}
      </div>
    </div>
  );
};

export default RepairRequest;
