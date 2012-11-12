package com.teamx.dao;

import java.util.List;
import com.teamx.domain.Klas;

public interface KlasDao {
	public List<Klas> findAll();
	public Klas findKlasById(int id);
	public void create(Klas klas);
	public void delete(int id);
	public void delete(Klas klas);
}
