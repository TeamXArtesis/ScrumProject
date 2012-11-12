package com.teamx.dao;

import java.util.List;
import com.teamx.domain.Docent;

public interface DocentDao {
	public List<Docent> findAll();
	public Docent findDocentById(int id);
	public void create(Docent docent);
	public void delete(int id);
	public void delete(Docent docent);
}
