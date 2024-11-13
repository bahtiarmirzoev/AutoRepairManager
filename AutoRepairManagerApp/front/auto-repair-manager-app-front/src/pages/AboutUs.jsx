import React from "react";

const AboutUs = () => {
  return (
    <div className="p-20 bg-gradient-to-b from-gray-200 via-gray-100 to-white text-gray-800">
      <section className="mb-16 text-center">
        <h1 className="text-5xl font-bold mb-6 text-gray-900 tracking-wide">
          О нас
        </h1>
        <p className="text-lg max-w-3xl mx-auto leading-relaxed text-gray-700">
          Мы - команда экспертов в области автосервиса, стремящаяся предоставить
          клиентам высочайшее качество обслуживания и уверенность в надежности
          их транспортных средств. Наш приоритет — индивидуальный подход и
          превосходные результаты.
        </p>
      </section>

      <section className="mb-16">
        <h2 className="text-4xl font-semibold mb-8 text-center text-gray-900">
          Наши преимущества
        </h2>
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-12 max-w-6xl mx-auto">
          <div className="bg-white p-8 rounded-lg shadow-md transform hover:scale-105 transition-transform duration-300">
            <h3 className="text-2xl font-bold mb-4 text-gray-800">
              Квалифицированные специалисты
            </h3>
            <p>
              Наши сотрудники имеют высокую квалификацию и многолетний опыт
              работы, что позволяет выполнять услуги на высшем уровне.
            </p>
          </div>
          <div className="bg-white p-8 rounded-lg shadow-md transform hover:scale-105 transition-transform duration-300">
            <h3 className="text-2xl font-bold mb-4 text-gray-800">
              Современное оборудование
            </h3>
            <p>
              Мы используем только самое современное оборудование,
              обеспечивающее точность диагностики и обслуживания.
            </p>
          </div>
          <div className="bg-white p-8 rounded-lg shadow-md transform hover:scale-105 transition-transform duration-300">
            <h3 className="text-2xl font-bold mb-4 text-gray-800">
              Индивидуальный подход
            </h3>
            <p>
              Мы предоставляем персонализированные решения каждому клиенту,
              чтобы наилучшим образом удовлетворить их потребности.
            </p>
          </div>
        </div>
      </section>
    </div>
  );
};

export default AboutUs;
