import React, { useState, useEffect } from "react";
import {
  FaWrench,
  FaCarBattery,
  FaOilCan,
  FaCarCrash,
  FaCogs,
  FaCarSide,
} from "react-icons/fa";

const Services = () => {
  const [servicesData, setServicesData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    // Fetch data from the backend API
    fetch("http://localhost:5271/api/AutoRepair/GetAll") // Replace with your backend API endpoint
      .then((response) => {
        if (!response.ok) {
          throw new Error("Failed to fetch services");
        }
        return response.json();
      })
      .then((data) => {
        setServicesData(data);
        setLoading(false);
      })
      .catch((error) => {
        setError(error.message);
        setLoading(false);
      });
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Error: {error}</div>;
  }

  return (
    <div className="p-20 bg-gradient-to-b from-gray-200 via-gray-100 to-white text-gray-800">
      {/* Заголовок страницы */}
      <section className="mb-16 text-center">
        <h1 className="text-5xl font-bold mb-6 text-gray-900 tracking-wide">
          Наши услуги
        </h1>
        <p className="text-lg max-w-3xl mx-auto leading-relaxed text-gray-700">
          Мы предлагаем широкий спектр услуг по обслуживанию и ремонту вашего
          автомобиля, гарантируя высокое качество и надежность.
        </p>
      </section>

      {/* Список услуг с анимацией */}
      <section className="mb-16">
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-12 max-w-6xl mx-auto">
          {servicesData.map((service, index) => (
            <div
              key={service.title} // Using title as key, or use a unique ID if available
              className="relative bg-white p-8 rounded-lg shadow-md transform hover:scale-105 transition-transform duration-300"
            >
              {/* Иконка услуги */}
              <div className="flex justify-center mb-4">{service.icon}</div>
              {/* Название и описание услуги */}
              <h3 className="text-2xl font-bold mb-4 text-gray-800">{service.title}</h3>
              <p className="leading-relaxed mb-4">{service.description}</p>
              {/* Стоимость услуги */}
              <p className="text-xl font-semibold text-indigo-600">{service.price}</p>
            </div>
          ))}
        </div>
      </section>
    </div>
  );
};

export default Services;
