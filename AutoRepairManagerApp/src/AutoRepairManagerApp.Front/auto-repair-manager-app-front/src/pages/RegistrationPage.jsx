import React, { useState } from "react";
import { FaUser, FaEnvelope, FaLock, FaCar } from "react-icons/fa";
import { Link } from "react-router-dom";

function RegistrationPage() {
  const [formData, setFormData] = useState({
    username: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Form submission logic here
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-blue-100 relative overflow-hidden">
      {/* Background with overlay */}
      <div
        className="absolute inset-0 bg-cover bg-center opacity-30"
        style={{ backgroundImage: "url('/path-to-your-car-image.jpg')" }}
      ></div>
      <div className="absolute inset-0 bg-gradient-to-br from-blue-500 via-blue-200 to-white opacity-70"></div>

      {/* Registration Form */}
      <div className="relative z-10 bg-white p-8 rounded-lg shadow-xl w-full max-w-md border border-blue-200">
        <h2 className="text-3xl font-bold text-center text-blue-500 flex items-center justify-center mb-6">
          <FaCar className="mr-2" /> Регистрация
        </h2>
        <p className="text-center text-gray-600 mb-4">
          Присоединяйтесь к нашему автосервису и получайте быстрый доступ к
          услугам
        </p>

        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="relative">
            <label htmlFor="username" className="text-gray-600">
              Имя пользователя
            </label>
            <div className="flex items-center border border-blue-300 rounded-md bg-white">
              <FaUser className="text-blue-400 mx-3" />
              <input
                type="text"
                id="username"
                name="username"
                value={formData.username}
                onChange={handleChange}
                className="w-full px-4 py-2 bg-transparent text-gray-700 focus:outline-none"
                placeholder="Введите имя пользователя"
                required
              />
            </div>
          </div>

          <div className="relative">
            <label htmlFor="email" className="text-gray-600">
              Email
            </label>
            <div className="flex items-center border border-blue-300 rounded-md bg-white">
              <FaEnvelope className="text-blue-400 mx-3" />
              <input
                type="email"
                id="email"
                name="email"
                value={formData.email}
                onChange={handleChange}
                className="w-full px-4 py-2 bg-transparent text-gray-700 focus:outline-none"
                placeholder="Введите email"
                required
              />
            </div>
          </div>

          <div className="relative">
            <label htmlFor="password" className="text-gray-600">
              Пароль
            </label>
            <div className="flex items-center border border-blue-300 rounded-md bg-white">
              <FaLock className="text-blue-400 mx-3" />
              <input
                type="password"
                id="password"
                name="password"
                value={formData.password}
                onChange={handleChange}
                className="w-full px-4 py-2 bg-transparent text-gray-700 focus:outline-none"
                placeholder="Введите пароль"
                required
              />
            </div>
          </div>

          <div className="relative">
            <label htmlFor="confirmPassword" className="text-gray-600">
              Подтвердите пароль
            </label>
            <div className="flex items-center border border-blue-300 rounded-md bg-white">
              <FaLock className="text-blue-400 mx-3" />
              <input
                type="password"
                id="confirmPassword"
                name="confirmPassword"
                value={formData.confirmPassword}
                onChange={handleChange}
                className="w-full px-4 py-2 bg-transparent text-gray-700 focus:outline-none"
                placeholder="Подтвердите пароль"
                required
              />
            </div>
          </div>

          <button
            type="submit"
            className="w-full py-2 mt-4 bg-blue-500 text-white rounded-md font-semibold hover:bg-blue-600 transition duration-200"
          >
            Зарегистрироваться
          </button>
        </form>

        <p className="text-center text-gray-500 mt-4">
          Уже зарегистрированы?{" "}
          <Link to="/LoginPage" className="text-blue-500 hover:underline">
            Войдите
          </Link>
        </p>
      </div>
    </div>
  );
}

export default RegistrationPage;
