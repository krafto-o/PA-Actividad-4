import tkinter as tk
from tkinter import messagebox

# Función para limpiar los campos del formulario
def borrar():
    tbNombre.delete(0, tk.END)
    tbApellidos.delete(0, tk.END)
    tbEdad.delete(0, tk.END)
    tbTelefono.delete(0, tk.END)
    tbEstatura.delete(0, tk.END)
    rbSeleccionGenero.set(0)

# Función para guardar los datos en un archivo de texto
def guardar():
    nombres = tbNombre.get()
    apellidos = tbApellidos.get()
    edad = tbEdad.get()
    tel = tbTelefono.get()
    estatura = tbEstatura.get()
    
    # Determinar el género seleccionado
    genero = ""
    seleccion = rbSeleccionGenero.get()
    if seleccion == 1:
        genero = "Masculino"
    elif seleccion == 2:
        genero = "Femenino"
    elif seleccion == 3:
        genero = "No Definido"

    # Preparar la cadena de datos para el archivo
    datos = (f"Nombre: {nombres}\n"
             f"Apellidos: {apellidos}\n"
             f"Edad: {edad}\n"
             f"Telefono: {tel}\n"
             f"Estatura: {estatura}\n"
             f"Genero: {genero}")

    # Guardar en el archivo .txt
    try:
        with open("Datos3N_13Feb26.txt", "a") as archivo:
            archivo.write(datos + "\n\n")
        
        # Mostrar mensaje de éxito
        messagebox.showinfo("Información", "Datos guardados correctamente\n\n" + datos)
    except Exception as e:
        messagebox.showerror("Error", f"No se pudo guardar el archivo: {e}")

# Configuración de la ventana principal
ventana = tk.Tk()
ventana.configure(bg="#9dceea")
ventana.geometry("350x650") # Ajusté un poco el alto para que quepa todo bien
ventana.title("Actividad 04 Formulario de Registro Vr. 001")

# Variable para los RadioButtons
rbSeleccionGenero = tk.IntVar()

# --- Diseño de la Interfaz ---

# Nombre
tk.Label(ventana, text="Nombre:", font=("Segoe UI", 14, "bold"), bg="#9dceea").pack(pady=(10, 0))
tbNombre = tk.Entry(ventana, width=35, justify="center")
tbNombre.pack(pady=5)

# Apellidos
tk.Label(ventana, text="Apellidos:", font=("Segoe UI", 14, "bold"), bg="#9dceea").pack(pady=(10, 0))
tbApellidos = tk.Entry(ventana, width=35, justify="center")
tbApellidos.pack(pady=5)

# Edad
tk.Label(ventana, text="Edad:", font=("Segoe UI", 14, "bold"), bg="#9dceea").pack(pady=(10, 0))
tbEdad = tk.Entry(ventana, width=10, justify="center")
tbEdad.pack(pady=5)

# Estatura
tk.Label(ventana, text="Estatura:", font=("Segoe UI", 14, "bold"), bg="#9dceea").pack(pady=(10, 0))
tbEstatura = tk.Entry(ventana, width=15, justify="center")
tbEstatura.pack(pady=5)

# Teléfono
tk.Label(ventana, text="Teléfono:", font=("Segoe UI", 14, "bold"), bg="#9dceea").pack(pady=(10, 0))
tbTelefono = tk.Entry(ventana, width=35, justify="center")
tbTelefono.pack(pady=5)

# Grupo de Género
gb = tk.LabelFrame(ventana, text="Seleccione un Género:", padx=10, pady=8, bg="#9dceea")
gb.pack(padx=10, pady=15)

tk.Radiobutton(gb, text="Masculino", value=1, variable=rbSeleccionGenero, bg="#9dceea").grid(column=1, row=1)
tk.Radiobutton(gb, text="Femenino", value=2, variable=rbSeleccionGenero, bg="#9dceea").grid(column=2, row=1)
tk.Radiobutton(gb, text="No Definido", value=3, variable=rbSeleccionGenero, bg="#9dceea").grid(column=3, row=1)

# Grupo de Botones
gb2 = tk.Frame(ventana, bg="#9dceea")
gb2.pack(pady=20)

btnGuardar = tk.Button(gb2, text="Guardar", width=10, command=guardar)
btnGuardar.grid(column=1, row=1, padx=10)

btnBorrar = tk.Button(gb2, text="Borrar", width=10, command=borrar)
btnBorrar.grid(column=2, row=1, padx=10)

# Iniciar la aplicación
ventana.mainloop()
