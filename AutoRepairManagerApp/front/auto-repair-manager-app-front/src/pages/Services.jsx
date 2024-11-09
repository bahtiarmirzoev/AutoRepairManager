import React from "react";
import {
  FaWrench,
  FaCarBattery,
  FaOilCan,
  FaCarCrash,
  FaCogs,
  FaCarSide,
} from "react-icons/fa";

const servicesData = [
  {
    title: "Диагностика и ремонт",
    description: "Полная диагностика и ремонт всех систем автомобиля.",
    icon: <FaWrench className="text-indigo-600" size={50} />,
    price: "от 500₼",
  },
  {
    title: "Ремонт после аварии",
    description: "Кузовной ремонт и восстановление автомобиля после ДТП.",
    icon: <FaCarCrash className="text-red-500" size={50} />,
    price: "от 500₼",
  },
  {
    title: "Замена аккумулятора",
    description: "Проверка состояния и замена автомобильного аккумулятора.",
    icon: <FaCarBattery className="text-yellow-500" size={50} />,
    price: "от 1500₼",
  },
  {
    title: "Замена масла",
    description: "Замена масла и фильтров для стабильной работы двигателя.",
    icon: <FaOilCan className="text-orange-600" size={50} />,
    price: "от 1000₼",
  },
  {
    title: "Техническое обслуживание",
    description: "Комплексное ТО с диагностикой всех систем.",
    icon: <FaCogs className="text-green-600" size={50} />,
    price: "от 300 ₼",
  },
  {
    title: "Замена шин и балансировка",
    description: "Сезонная замена шин и балансировка колес.",
    icon: <FaCarSide className="text-blue-500" size={50} />,
    price: "от 40₼",
  },
];

const Services = () => {
  return (
    <div className="p-10 bg-gradient-to-b from-gray-200 via-gray-100 to-white text-gray-800">
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
              key={index}
              className="relative bg-white p-8 rounded-lg shadow-md transform hover:scale-105 transition-transform duration-300"
            >
              {/* Иконка услуги */}
              <div className="flex justify-center mb-4">{service.icon}</div>
              {/* Название и описание услуги */}
              <h3 className="text-2xl font-bold mb-4 text-gray-800">
                {service.title}
              </h3>
              <p className="leading-relaxed mb-4">{service.description}</p>
              {/* Стоимость услуги */}
              <p className="text-xl font-semibold text-indigo-600">
                {service.price}
              </p>
            </div>
          ))}
        </div>
      </section>
    </div>
  );
};

export default Services;
