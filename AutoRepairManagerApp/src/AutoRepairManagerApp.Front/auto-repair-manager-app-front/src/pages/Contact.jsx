import React, { useState } from "react";
import {
  GoogleMap,
  LoadScript,
  Marker,
  InfoWindow,
} from "@react-google-maps/api";

const serviceLocations = [
  {
    name: "Автосервис Darnagul",
    address: "г. Баку, ул. Низами, 45",
    phone: "+994 55 123 4567",
    hours: "Пн-Пт: 9:00 - 19:00, Сб: 10:00 - 16:00",
    position: { lat: 40.414308, lng: 49.851272 },
  },
  {
    name: "Автосервис Yasamal",
    address: "г. Баку, ул. Азадлыг, 23",
    phone: "+994 55 234 5678",
    hours: "Пн-Сб: 8:00 - 18:00",
    position: { lat: 40.383261, lng: 49.825126 },
  },
  {
    name: "Автосервис Narimanov",
    address: "г. Баку, проспект Гейдара Алиева, 10",
    phone: "+994 55 345 6789",
    hours: "Пн-Пт: 9:00 - 19:00, Сб: 10:00 - 15:00",
    position: { lat: 40.408719, lng: 49.867092 },
  },
];

const mapContainerStyle = {
  width: "100%",
  height: "400px",
};

const center = { lat: 40.409264, lng: 49.867092 };

const Contacts = () => {
  const [selectedLocation, setSelectedLocation] = useState(null);

  return (
    <div className="p-20 bg-gradient-to-b from-gray-200 via-gray-100 to-white text-gray-800">
      <section className="mb-16 text-center">
        <h1 className="text-5xl font-bold mb-6 text-gray-900 tracking-wide">
          Контакты
        </h1>
        <p className="text-lg max-w-3xl mx-auto leading-relaxed text-gray-700">
          Свяжитесь с нами или посетите один из наших автосервисов в вашем
          городе.
        </p>
      </section>

      <section className="relative mb-16">
        <h2 className="text-4xl font-semibold mb-8 text-center text-gray-900">
          Наше расположение
        </h2>
        <div className="relative w-full max-w-5xl mx-auto shadow-2xl rounded-lg overflow-hidden">
          <LoadScript googleMapsApiKey="AIzaSyAg27XnuePBJeRK7-mPoOmlxEKhOZm4U3U">
            <GoogleMap
              mapContainerStyle={mapContainerStyle}
              center={center}
              zoom={12}
            >
              {serviceLocations.map((location, index) => (
                <Marker
                  key={index}
                  position={location.position}
                  title={location.name}
                  onClick={() => setSelectedLocation(location)}
                />
              ))}

              {selectedLocation && (
                <InfoWindow
                  position={selectedLocation.position}
                  onCloseClick={() => setSelectedLocation(null)}
                >
                  <div>
                    <h3 className="font-bold">{selectedLocation.name}</h3>
                    <p>Адрес: {selectedLocation.address}</p>
                    <p>Телефон: {selectedLocation.phone}</p>
                    <p>Часы работы: {selectedLocation.hours}</p>
                  </div>
                </InfoWindow>
              )}
            </GoogleMap>
          </LoadScript>
        </div>
      </section>
    </div>
  );
};

export default Contacts;
