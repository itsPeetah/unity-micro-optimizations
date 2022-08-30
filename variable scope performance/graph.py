import matplotlib.pyplot as plt

cols = [1866, 1669, 267, 262]
names = ["Property", "Field", "Local", "Local (Re-declared)"]

fig = plt.figure()
ax = fig.add_subplot(111)
ax.bar(names, cols)
ax.set_title("Average performance")
ax.set_ylabel("Milliseconds")
fig.savefig("graph.png", facecolor='white', transparent=False)
plt.show()
