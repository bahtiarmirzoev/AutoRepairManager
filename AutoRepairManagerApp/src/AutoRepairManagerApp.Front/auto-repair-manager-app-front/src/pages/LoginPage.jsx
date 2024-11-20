import React, { useState } from "react";
import { FaEnvelope, FaLock, FaCar } from "react-icons/fa";
import { Link } from "react-router-dom";

function LoginPage() {
  const [formData, setFormData] = useState({
    email: "",
    password: "",
  });
  

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const  response = await fetch("https://localhost:5271/api/Identity/Login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(formData),
      });

      if (!response.ok) {
        throw new Error("Invalid email or password");
      }

      const data = await response.json();

      localStorage.setItem("token", data.token);

      //navigate("/Home");
    } catch (err) {
      //setError(err.message);
    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-blue-100 relative overflow-hidden">
      {/* Background with overlay */}
      <div
        className="absolute inset-0 bg-cover bg-center opacity-30"
        style={{ backgroundImage: "url('/path-to-your-car-image.jpg')" }}
      ></div>
      <div className="absolute inset-0 bg-gradient-to-br from-blue-500 via-blue-200 to-white opacity-70"></div>

      {/* Login Form */}
      <div className="relative z-10 bg-white bg-opacity-90 p-8 rounded-lg shadow-xl w-full max-w-md">
        <h2 className="text-3xl font-bold text-center text-blue-600 flex items-center justify-center mb-6">
          <FaCar className="mr-2" /> Вход
        </h2>
        <p className="text-center text-blue-500 mb-4">
          Войдите в систему для доступа к услугам автосервиса
        </p>

        <form onSubmit={handleSubmit} className="space-y-4">
          {/* Email Field */}
          <div className="relative">
            <label htmlFor="email" className="text-blue-600">
              Email
            </label>
            <div className="flex items-center border border-blue-400 rounded-md bg-blue-50">
              <FaEnvelope className="text-blue-400 mx-3" />
              <input
                type="email"
                id="email"
                name="email"
                value={formData.email}
                onChange={handleChange}
                className="w-full px-4 py-2 bg-transparent text-blue-700 focus:outline-none"
                placeholder="Введите email"
                required
              />
            </div>
          </div>

          {/* Password Field */}
          <div className="relative">
            <label htmlFor="password" className="text-blue-600">
              Пароль
            </label>
            <div className="flex items-center border border-blue-400 rounded-md bg-blue-50">
              <FaLock className="text-blue-400 mx-3" />
              <input
                type="password"
                id="password"
                name="password"
                value={formData.password}
                onChange={handleChange}
                className="w-full px-4 py-2 bg-transparent text-blue-700 focus:outline-none"
                placeholder="Введите пароль"
                required
              />
            </div>
          </div>

          <button
            type="submit"
            className="w-full py-2 mt-4 bg-blue-500 text-white rounded-md font-semibold hover:bg-blue-600 transition duration-200"
          >
            Войти
          </button>
        </form>

        <p className="text-center text-blue-500 mt-4">
          Ещё не зарегистрированы?{" "}
          <Link
            to="/RegistrationPage"
            className="text-blue-600 hover:underline"
          >
            Зарегистрироваться
          </Link>
        </p>
      </div>
    </div>
  );
}

export default LoginPage;
