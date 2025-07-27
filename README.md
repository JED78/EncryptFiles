# EncryptFiles

**EncryptFiles** es una aplicación de escritorio en **C# (.NET Framework/.NET)** que permite cifrar y descifrar archivos de forma segura mediante una interfaz de **Windows Forms (WinForms)**.

---

## 🛡️ Descripción

EncryptFiles proporciona una forma intuitiva y segura para proteger archivos sensibles. Utiliza algoritmos criptográficos estándares y una interfaz gráfica simple, ideal para usuarios no técnicos.

---

## 🧰 Funcionalidades principales

- Cifrado y descifrado de archivos a través de WinForms.
- Selección de archivos mediante diálogo (OpenFileDialog / SaveFileDialog).
- Solicitud de contraseña a través de un formulario modal (un `PasswordDialog`) cuyas propiedades están protegidas (`PasswordChar='*'`) :contentReference[oaicite:1]{index=1}.
- Criptografía basada en AES (CBC o GCM) u algoritmo similar, mediante `System.Security.Cryptography`.
- Soporte para procesamiento de archivos en streaming para manejar contenidos grandes sin cargar todo en memoria :contentReference[oaicite:2]{index=2}.
- Interfaz minimalista con botones `Encrypt`, `Decrypt` y selección de archivo.

---

## ⚙️ Requisitos

- Windows con .NET Framework 4.x o .NET 6+ (si tu proyecto es .NET Core/5/6/7 con WinForms).
- Visual Studio 2019/2022 con soporte para WinForms.
- Librerías estándar:
  - `System.Security.Cryptography`
  - `System.Windows.Forms`
  - `System.IO`

---

## 📥 Instalación

```bash
git clone https://github.com/JED78/EncryptFiles.git
cd EncryptFiles
